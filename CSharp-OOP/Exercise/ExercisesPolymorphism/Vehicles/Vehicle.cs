using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuanity = 0;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
            if (tankCapacity >= fuelQuantity)
            {
                this.FuelQuanity = fuelQuantity;
            }
        }

        public double FuelQuanity { get; set; }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; private set; }
        

        public virtual void Drive(double distance)
        {
            if (FuelConsumption * distance < FuelQuanity)
            {
                FuelQuanity -= FuelConsumption * distance;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                throw new Exception($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new Exception("Fuel must be a positive number");
            }
            if(fuel + FuelQuanity > TankCapacity)
            {
                throw new Exception($"Cannot fit {fuel} fuel in the tank");
            }
            this.FuelQuanity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuanity:f2}";
        }
    }
}
