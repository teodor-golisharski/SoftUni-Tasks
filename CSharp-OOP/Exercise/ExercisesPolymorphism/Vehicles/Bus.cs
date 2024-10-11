using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override void Drive(double distance)
        {
            if ((FuelConsumption + 1.4) * distance < FuelQuanity)
            {
                FuelQuanity -= (FuelConsumption + 1.4) * distance;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                throw new Exception($"{this.GetType().Name} needs refueling");
            }
        }
        public void DriveEmpty(double distance)
        {
            base.Drive(distance);
        }
    }
}
