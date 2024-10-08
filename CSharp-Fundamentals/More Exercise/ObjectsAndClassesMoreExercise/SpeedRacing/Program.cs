using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);
                if (!cars.Any(x => x.Model == model))
                {
                    Car car = new Car(model, fuelAmount, fuelConsumption);
                    cars.Add(car);
                }
            }
            string[] command = Console.ReadLine().Split();
            while (command[0] != "End")
            {
                string model = command[1];
                double distance = double.Parse(command[2]);
                Car car = cars.Where(x => x.Model == model).ToList().First();
                if (cars.Contains(car))
                {
                    car.FuelCalculator(car, distance);
                }
                command = Console.ReadLine().Split();
            }
            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Model} {item.FuelAmount:f2} {item.Distance}");
            }
        }
    }
    class Car
    {
        public Car()
        {

        }
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumption = fuelConsumption;
            Distance = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumption { get; set; }
        public double Distance { get; set; }

        public void FuelCalculator(Car car, double distance)
        {
            double consumed = car.FuelConsumption * distance;
            if (consumed <= car.FuelAmount)
            {
                car.FuelAmount = car.FuelAmount - consumed;
                car.Distance = car.Distance + distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
