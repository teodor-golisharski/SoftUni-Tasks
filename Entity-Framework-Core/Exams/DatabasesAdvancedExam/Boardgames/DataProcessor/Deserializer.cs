namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Boardgames.Utilities;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCreatorDto[] creatorDtos = xmlHelper.Deserialize<ImportCreatorDto[]>(xmlString, "Creators");

            ICollection<Creator> validCreators = new HashSet<Creator>();
            foreach (ImportCreatorDto creatorDto in creatorDtos)
            {
                if (!IsValid(creatorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                ICollection<Boardgame> validBoardgames = new HashSet<Boardgame>();
                foreach (ImportCreatorBoardgameDto boardgameDto in creatorDto.BoardgameDtos)
                {
                    if (!IsValid(boardgameDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Boardgame b = new Boardgame()
                    {
                        Name = boardgameDto.Name,
                        Rating = boardgameDto.Rating,
                        YearPublished = boardgameDto.YearPublished,
                        CategoryType = (CategoryType)boardgameDto.CategoryType,
                        Mechanics = boardgameDto.Mechanics
                    };
                    validBoardgames.Add(b);
                }

                Creator c = new Creator()
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName,
                    Boardgames = validBoardgames
                };

                validCreators.Add(c);

                sb.AppendLine(string.Format
                    (SuccessfullyImportedCreator, c.FirstName, c.LastName, validBoardgames.Count));
            }
            context.Creators.AddRange(validCreators);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var jsonSellerDtos =
                JsonConvert.DeserializeObject<ImportJsonSellerDto[]>(jsonString);

            //Valid data
            var validSellers = new HashSet<Seller>();

            //Sellers
            foreach (var seller in jsonSellerDtos)
            {
                if (!IsValid(seller))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Seller s = new Seller()
                {
                    Name = seller.Name,
                    Address = seller.Address,
                    Country = seller.Country,
                    Website = seller.Website
                };

                //Boardgames id in every Seller
                foreach (int id in seller.Boardgames.Distinct())
                {
                    if (!context.Boardgames.Any(x => x.Id == id))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    BoardgameSeller boardgameSeller = new BoardgameSeller()
                    {
                        BoardgameId = id,
                        Seller = s
                    };
                    s.BoardgamesSellers.Add(boardgameSeller);
                }
                validSellers.Add(s);
                sb.AppendLine(string.Format(SuccessfullyImportedSeller, s.Name, s.BoardgamesSellers.Count()));
            }
            //Add range
            context.Sellers.AddRange(validSellers);

            //Save changes
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
