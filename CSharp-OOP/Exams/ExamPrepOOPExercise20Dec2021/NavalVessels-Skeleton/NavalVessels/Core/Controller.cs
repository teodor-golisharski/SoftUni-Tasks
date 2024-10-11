using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        public Controller()
        {
            captains = new List<ICaptain>();
            vessels = new VesselRepository();
        }

        private IRepository<IVessel> vessels;
        private ICollection<ICaptain> captains;


        //Business logic:

        //Done
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {


            if (captains.FirstOrDefault(x => x.FullName == selectedCaptainName) == null)
            {
                return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            if (vessels.FindByName(selectedVesselName) == null)
            {
                return String.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            if (vessels.FindByName(selectedVesselName).Captain != null)
            {
                return String.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }
            else
            {
                ICaptain captain = captains.FirstOrDefault(x => x.FullName == selectedCaptainName);

                vessels.FindByName(selectedVesselName).Captain = captain;

                captain.AddVessel(vessels.FindByName(selectedVesselName));

                return String.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
            }
        }

        //Done
        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            if (vessels.FindByName(attackingVesselName) == null)
            {
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            if (vessels.FindByName(defendingVesselName) == null)
            {
                return String.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }
            if (vessels.FindByName(attackingVesselName).ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            if (vessels.FindByName(defendingVesselName).ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }
            IVessel attacker = vessels.FindByName(attackingVesselName);
            IVessel defender = vessels.FindByName(defendingVesselName);

            attacker.Attack(defender);

            attacker.Captain.IncreaseCombatExperience();
            defender.Captain.IncreaseCombatExperience();

            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defender.ArmorThickness);
        }

        //Done
        public string CaptainReport(string captainFullName)
        {
            return captains.FirstOrDefault(x => x.FullName == captainFullName).Report();
        }

        //Done
        public string HireCaptain(string fullName)
        {
            if (captains.Any(x => x.FullName == fullName))
            {
                return String.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }
            else
            {
                ICaptain captain = new Captain(fullName);

                captains.Add(captain);

                return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
            }
        }

        //Done
        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = vessels.FindByName(name);

            if (vessel != null)
            {
                return String.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }
            if (vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                return String.Format(OutputMessages.InvalidVesselType);
            }

            vessels.Add(vessel);
            return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        //Done
        public string ServiceVessel(string vesselName)
        {
            if (vessels.FindByName(vesselName) == null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }
            else
            {
                vessels.FindByName(vesselName).RepairVessel();
                return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
            }
        }

        //Done
        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);
            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }
            else if (vessel.GetType() == typeof(Battleship))
            {
                Battleship battleshipVessel = (Battleship)vessel;

                battleshipVessel.ToggleSonarMode();

                return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else if (vessel.GetType() == typeof(Submarine))
            {
                Submarine submarineVessel = (Submarine)vessel;

                submarineVessel.ToggleSubmergeMode();

                return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }
            return null;
        }

        //Done
        public string VesselReport(string vesselName)
        {
            return vessels.FindByName(vesselName).ToString();
        }
    }
}
