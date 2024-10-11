using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            this.DelicacyMenu = new DelicacyRepository();
            this.CocktailMenu = new CocktailRepository();
        }

        private int capacity;
        private double currentBill = 0;
        private double turnover = 0;
        private bool isReserved = false;

        public int BoothId
        {
            get;
            private set;
        }

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0!");
                }
                this.capacity = value;
            }
        }


        public IRepository<IDelicacy> DelicacyMenu { get; }

        public IRepository<ICocktail> CocktailMenu { get; }

        public double CurrentBill
        {
            get { return currentBill; }
            private set
            {
                currentBill = value;
            }
        }

        public double Turnover
        {
            get { return turnover; }
            private set
            {
                turnover = value;
            }
        }

        public bool IsReserved
        {
            get { return isReserved; }
            private set
            {
                isReserved = value;
            }
        }

        public void ChangeStatus()
        {
            if(IsReserved == true)
            {
                IsReserved = false;
            }
            if (IsReserved == false)
            {
                IsReserved = true;
            }
        }

        public void Charge()
        {
            Turnover += currentBill;
            CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:f2} lv");
            sb.AppendLine($"-Cocktail menu:");
            foreach (var item in CocktailMenu.Models)
            {
                sb.AppendLine($"--{item:F2}");
            }
            sb.AppendLine($"-Delicacy menu:");
            foreach (var item in DelicacyMenu.Models)
            {
                sb.AppendLine($"--{item:F2}");
            }
            return sb.ToString().Trim();
        }
    }
}
