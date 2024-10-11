using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {

        private const double initialArmorThickness = 200;

        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, initialArmorThickness)
        {
            SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }

        public override void RepairVessel()
        {
            if (ArmorThickness < initialArmorThickness)
            {
                ArmorThickness = initialArmorThickness;
            }
        }

        public void ToggleSubmergeMode()
        {
            if (SubmergeMode == false)
            {
                SubmergeMode = true;
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else if (SubmergeMode == true)
            {
                SubmergeMode = false;
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            if (SubmergeMode == true)
            {
                sb.AppendLine(" *Submerge mode: ON");
            }
            else
            {
                sb.AppendLine(" *Submerge mode: OFF");
            }

            return sb.ToString().Trim();
        }
    }
}
