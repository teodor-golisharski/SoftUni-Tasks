using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(200, 100);
            Console.WriteLine(raceMotorcycle.FuelConsumption);
        }
    }
}
