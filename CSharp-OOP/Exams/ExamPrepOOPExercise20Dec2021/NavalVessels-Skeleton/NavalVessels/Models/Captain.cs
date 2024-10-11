using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        public Captain(string fullName)
        {
            this.FullName = fullName;
            this.Vessels = new List<IVessel>();
        }

        private string fullName;
        private int combatExperience = 0;

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                fullName = value;
            }
        }


        public int CombatExperience
        {
            get { return combatExperience; }
            private set
            {
                combatExperience = value;
            }
        }

        public ICollection<IVessel> Vessels { get; private set; }

        public void AddVessel(IVessel vessel)
        {
            if(vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }
            Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.");

            foreach (var item in Vessels)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
