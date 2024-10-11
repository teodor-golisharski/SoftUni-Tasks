using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            if (pilotRepository.FindByName(pilotName) == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            if (pilotRepository.FindByName(pilotName).CanRace == true)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            if (carRepository.FindByName(carModel) == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilotRepository.FindByName(pilotName).AddCar(carRepository.FindByName(carModel));

            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, pilotRepository.FindByName(pilotName).Car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            if (raceRepository.FindByName(raceName) == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if (pilotRepository.FindByName(pilotFullName) == null
                || pilotRepository.FindByName(pilotFullName).CanRace == false
                || raceRepository.FindByName(raceName).Pilots.Any(x => x.FullName == pilotFullName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            raceRepository.FindByName(raceName).AddPilot(pilotRepository.FindByName(pilotFullName));

            return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (carRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            IFormulaOneCar car;
            switch (type)
            {
                case "Ferrari": car = new Ferrari(model, horsepower, engineDisplacement); break;

                case "Williams": car = new Williams(model, horsepower, engineDisplacement); break;

                default:
                    throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }
            carRepository.Add(car);

            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            IPilot pilot = new Pilot(fullName);

            pilotRepository.Add(pilot);

            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            IRace race = new Race(raceName, numberOfLaps);

            raceRepository.Add(race);

            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in pilotRepository.Models.OrderByDescending(x => x.NumberOfWins))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in raceRepository.Models.Where(x => x.TookPlace == true))
            {
                sb.AppendLine(item.RaceInfo());    
            }

            return sb.ToString().Trim();
        }

        public string StartRace(string raceName)
        {
            StringBuilder sb = new StringBuilder();

            if (raceRepository.FindByName(raceName) == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if (raceRepository.FindByName(raceName).Pilots.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if (raceRepository.FindByName(raceName).TookPlace == true)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            IRace race = raceRepository.FindByName(raceName);

            

            int postition = 1;
            foreach (var item in race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)))
            {
                if(postition>3)
                {
                    break;
                }
                if (postition == 1)
                {
                    pilotRepository.FindByName(item.FullName).WinRace();
                    sb.AppendLine(string.Format(OutputMessages.PilotFirstPlace, item.FullName, raceName));
                }
                if(postition == 2)
                {
                    sb.AppendLine(string.Format(OutputMessages.PilotSecondPlace, item.FullName, raceName));

                }
                if (postition == 3)
                {
                    sb.AppendLine(string.Format(OutputMessages.PilotThirdPlace, item.FullName, raceName));
                }
                postition++;    
            }

            race.TookPlace = true;

            return sb.ToString().Trim();
        }
    }
}
