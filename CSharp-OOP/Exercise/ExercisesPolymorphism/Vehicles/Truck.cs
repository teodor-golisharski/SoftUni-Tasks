using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            FuelConsumption += 1.6;
        }

        public override void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new Exception("Fuel must be a positive number");
            }
            if (fuel + FuelQuanity > TankCapacity)
            {
                throw new Exception($"Cannot fit {fuel} fuel in the tank");
            }
            this.FuelQuanity += fuel * 0.95;
        }
    }
}
