using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        public Pilot(string fullName)
        {
            this.FullName = fullName;
        }

        private string fullName;
        private IFormulaOneCar car;
        private int numberOfWins = 0;
        private bool canRace = false;

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }
                fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get { return car; }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException(string.Format(ExceptionMessages.InvalidCarForPilot, value));
                }
                car = value;
            }
        }

        public int NumberOfWins
        {
            get { return numberOfWins; }
            private set { numberOfWins = value; } 
        }

        public bool CanRace
        {
            get { return canRace; }
            private set { canRace = value; }
        }

        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            canRace = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {FullName} has {NumberOfWins} wins.";
        }
    }
}
