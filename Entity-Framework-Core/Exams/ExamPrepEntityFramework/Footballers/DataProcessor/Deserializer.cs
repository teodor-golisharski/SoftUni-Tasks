namespace Footballers.DataProcessor
{
    using AutoMapper;
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCoachesDto[]), new XmlRootAttribute("Coaches"));

            using StringReader stringReader = new StringReader(xmlString);

            ImportCoachesDto[] coachDtos = (ImportCoachesDto[])xmlSerializer.Deserialize(stringReader)!;

            List<Coach> coaches = new List<Coach>();

            foreach (ImportCoachesDto coachDto in coachDtos)
            {
                if (!IsValid(coachDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                // check here later
                string nationality = coachDto.Nationality;
                bool isNationalityInvalid = string.IsNullOrEmpty(nationality);

                if (isNationalityInvalid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Coach c = new Coach()
                {
                    Name = coachDto.Name,
                    Nationality = nationality
                };

                foreach (ImportFootballersDto footballerDto in coachDto.Footballers)
                {
                    if (!IsValid(footballerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime footballerContractStartDate;
                    bool isFootballerContractStartDateValid = DateTime.TryParseExact(footballerDto.ContractStartDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out footballerContractStartDate);
                    if (!isFootballerContractStartDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime footballerContractEndDate;
                    bool isFootballerContractEndDateValid = DateTime.TryParseExact(footballerDto.ContractEndDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out footballerContractEndDate);
                    if (!isFootballerContractEndDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (footballerContractStartDate >= footballerContractEndDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer f = new Footballer()
                    {
                        Name = footballerDto.Name,
                        ContractStartDate = footballerContractStartDate,
                        ContractEndDate = footballerContractEndDate,
                        BestSkillType = (BestSkillType)footballerDto.BestSkillType,
                        PositionType = (PositionType)footballerDto.PositionType
                    };

                    c.Footballers.Add(f);
                }
                coaches.Add(c);
                sb.AppendLine(String.Format(SuccessfullyImportedCoach, c.Name, c.Footballers.Count));
            }
            context.Coaches.AddRange(coaches);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportTeamDto[] teamDtos = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);

            List<Team> teams = new List<Team>();

            foreach (ImportTeamDto teamDto in teamDtos)
            {
                if (!IsValid(teamDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team t = new Team()
                {
                    Name = teamDto.Name,
                    Nationality = teamDto.Nationality,
                    Trophies = teamDto.Trophies,
                };

                if (t.Trophies == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (int footballerId in teamDto.Footballers.Distinct())
                {
                    Footballer f = context.Footballers.Find(footballerId);
                    if (f == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    t.TeamsFootballers.Add(new TeamFootballer()
                    {
                        Footballer = f
                    });
                }
                teams.Add(t);
                sb.AppendLine(String.Format(SuccessfullyImportedTeam, t.Name, t.TeamsFootballers.Count));
            }
            context.Teams.AddRange(teams);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

    }
}
