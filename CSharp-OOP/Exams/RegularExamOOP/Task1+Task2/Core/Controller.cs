using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using System.Linq;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using System.Diagnostics;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private Type ginger = typeof(Gingerbread);
        private Type stolen = typeof(Stolen);
        private Type hibernation = typeof(Hibernation);
        private Type mulledWine = typeof(MulledWine);

        private BoothRepository boothRepository;

        public Controller()
        {
            this.boothRepository = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            IBooth booth = new Booth(boothRepository.Models.Count + 1, capacity);
            boothRepository.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, booth.BoothId, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != hibernation.Name && cocktailTypeName != mulledWine.Name)
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            if (boothRepository.Models.First(x => x.BoothId == boothId).CocktailMenu.Models.Any(x => x.Name == cocktailName && x.Size == size))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, cocktailTypeName, size);
            }

            ICocktail cocktail;

            if (cocktailTypeName == "Hibernation")
            {
                cocktail = new Hibernation(cocktailName, size);
                boothRepository.Models.First(x => x.BoothId == boothId).CocktailMenu.AddModel(cocktail);
            }
            else if (cocktailTypeName == "MulledWine")
            {
                cocktail = new MulledWine(cocktailName, size);
                boothRepository.Models.First(x => x.BoothId == boothId).CocktailMenu.AddModel(cocktail);
            }

            return String.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != ginger.Name && delicacyTypeName != stolen.Name)
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            if (boothRepository.Models.First(x => x.BoothId == boothId).DelicacyMenu.Models.Any(x => x.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyTypeName);
            }

            IDelicacy delicacy;

            if (delicacyTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(delicacyName);
                boothRepository.Models.First(x => x.BoothId == boothId).DelicacyMenu.AddModel(delicacy);
            }
            else if (delicacyTypeName == "Stolen")
            {
                delicacy = new Stolen(delicacyName);
                boothRepository.Models.First(x => x.BoothId == boothId).DelicacyMenu.AddModel(delicacy);
            }

            return String.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in boothRepository.Models.Where(x => x.BoothId == boothId))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }

        public string LeaveBooth(int boothId)
        {
            double currentBill = boothRepository.Models.First(x => x.BoothId == boothId).CurrentBill;
            boothRepository.Models.First(x => x.BoothId == boothId).Charge();
            boothRepository.Models.First(x => x.BoothId == boothId).ChangeStatus();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.GetBill, $"{currentBill:f2}"));
            sb.AppendLine(string.Format(OutputMessages.BoothIsAvailable, boothId));

            return sb.ToString().Trim();
        }

        public string ReserveBooth(int countOfPeople)
        {
            boothRepository.Models.Where(x => x.IsReserved == false && x.Capacity >= countOfPeople).OrderBy(x => x.Capacity).ThenByDescending(x => x.BoothId);
            
            if (boothRepository.Models.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= countOfPeople) == null)
            {
                return String.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }
            else
            {
                int res = boothRepository.Models.OrderBy(x => x.Capacity).ThenByDescending(x => x.BoothId).First(x => x.IsReserved == false && x.Capacity >= countOfPeople).BoothId;
                boothRepository.Models.OrderBy(x => x.Capacity).ThenByDescending(x => x.BoothId).First(x => x.IsReserved == false && x.Capacity >= countOfPeople).ChangeStatus();
                return String.Format(OutputMessages.BoothReservedSuccessfully, res, countOfPeople);
            }
        }

        public string TryOrder(int boothId, string order)
        {
            string[] tokens = order
                .Split("/", StringSplitOptions.RemoveEmptyEntries);

            string itemTypeName = tokens[0]; //Gingerbread...
            string itemName = tokens[1]; //Santabiscuit
            int count = int.Parse(tokens[2]); //2

            ICocktail cocktail;
            IDelicacy delicacy;

            if (itemTypeName == "Gingerbread" || itemTypeName == "Stolen")
            {
                if (boothRepository.Models.First(x => x.BoothId == boothId).DelicacyMenu.Models.Any(x => x.Name == itemName))
                {
                    switch (itemTypeName)
                    {
                        case "Gingerbread":
                            delicacy = new Gingerbread(itemName);
                            boothRepository.Models.First(x => x.BoothId == boothId).UpdateCurrentBill(delicacy.Price * count);
                            break;

                        case "Stolen":
                            delicacy = new Stolen(itemName);
                            boothRepository.Models.First(x => x.BoothId == boothId).UpdateCurrentBill(delicacy.Price * count);
                            break;
                    }
                    return String.Format(OutputMessages.SuccessfullyOrdered, boothId, count, itemName);
                }
                else
                {
                    return String.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }
            }
            else if (itemTypeName == "Hibernation" || itemTypeName == "MulledWine")
            {
                string size = tokens[3];
                bool flagName = boothRepository.Models.First(x => x.BoothId == boothId).CocktailMenu.Models.Any(x => x.Name == itemName);
                bool flagSize = boothRepository.Models.First(x => x.BoothId == boothId).CocktailMenu.Models.Any(x => x.Size == size);
                if (flagName && flagSize)
                {
                    switch (itemTypeName)
                    {
                        case "Hibernation":
                            cocktail = new Hibernation(itemName, size);
                            boothRepository.Models.First(x => x.BoothId == boothId).UpdateCurrentBill(cocktail.Price * count);
                            break;

                        case "MulledWine":
                            cocktail = new MulledWine(itemName, size);
                            boothRepository.Models.First(x => x.BoothId == boothId).UpdateCurrentBill(cocktail.Price * count);
                            break;
                    }
                    return String.Format(OutputMessages.SuccessfullyOrdered, boothId, count, itemName);
                }
                else
                {
                    return String.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }
            }
            return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
        }
    }
}
