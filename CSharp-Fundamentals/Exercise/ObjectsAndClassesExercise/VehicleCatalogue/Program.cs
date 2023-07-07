using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            List<Vehicle> cars = new List<Vehicle>();
            List<Vehicle> trucks = new List<Vehicle>();
            string[] input = Console.ReadLine().Split();
            while (input[0] != "End")
            {
                string type = input[0];
                string model = input[1];
                string color = input[2];
                int horsepower = int.Parse(input[3]);
                Vehicle current = new Vehicle()
                {
                    Type = type,
                    Model = model,
                    Color = color,
                    Horsepower = horsepower
                };
                bool carExist = cars.Any(x => x.Model == current.Model);
                bool truckExist = trucks.Any(x => x.Model == current.Model);
                if (current.Type == "car" && carExist == false)
                {
                    current.Type = "Car";
                    cars.Add(current);
                    vehicles.Add(current);
                }
                else if (current.Type == "truck" && truckExist == false)
                {
                    current.Type = "Truck";
                    trucks.Add(current);
                    vehicles.Add(current);
                }
                input = Console.ReadLine().Split();
            }
            string command = Console.ReadLine();
            while (command != "Close the Catalogue")
            {
                foreach (var item in vehicles)
                {
                    if (item.Model == command)
                    {
                        Console.WriteLine($"Type: {item.Type}");
                        Console.WriteLine($"Model: {item.Model}");
                        Console.WriteLine($"Color: {item.Color}");
                        Console.WriteLine($"Horsepower: {item.Horsepower}");
                        break;
                    }
                }
                command = Console.ReadLine();
            }
            double totalCarHp = 0;
            foreach (var item in cars)
            {
                totalCarHp += item.Horsepower;
            }
            double totalTruckHp = 0;
            foreach (var item in trucks)
            {
                totalTruckHp += item.Horsepower;
            }

            double avgCars = totalCarHp / cars.Count;
            double avgTrucks = totalTruckHp / trucks.Count;
            if (cars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {avgCars:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }
            if (trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {avgTrucks:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }
    }
    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
    }
}
