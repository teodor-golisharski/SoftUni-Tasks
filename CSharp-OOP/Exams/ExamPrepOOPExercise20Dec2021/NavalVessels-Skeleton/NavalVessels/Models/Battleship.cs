using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double initialArmorThickness = 300;
        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, initialArmorThickness)
        {
            SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public override void RepairVessel()
        {
            if (ArmorThickness < initialArmorThickness)
            {
                ArmorThickness = initialArmorThickness;
            }
        }

        public void ToggleSonarMode()
        {
            if (SonarMode == false)
            {
                SonarMode = true;
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else if (SonarMode == true)
            {
                SonarMode = false;
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            if (SonarMode == true)
            {
                sb.AppendLine(" *Sonar mode: ON");
            }
            else
            {
                sb.AppendLine(" *Sonar mode: OFF");
            }

            return sb.ToString().Trim();
        }
    }
}
