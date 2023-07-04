using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('/');
            Catalog catalog = new Catalog();
            while (input[0] != "end")
            {
                string type = input[0];
                string brand = input[1];
                string model = input[2];
                int extra = int.Parse(input[3]);
                Truck truck = new Truck()
                {
                    Brand = brand,
                    Model = model,
                    Weight = extra
                };
                if (type == "Car")
                {
                    catalog.Cars.Add(new Car
                    {
                        Brand = brand,
                        Model = model,
                        HP = extra
                    });
                }
                else if (type == "Truck")
                {
                    catalog.Trucks.Add(new Truck
                    {
                        Brand = brand,
                        Model = model,
                        Weight = extra
                    });
                }
                input = Console.ReadLine().Split('/');
            }
            if (catalog.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car item in catalog.Cars.OrderBy(car => car.Brand))
                {
                    Console.WriteLine($"{item.Brand}: {item.Model} - {item.HP}hp");
                }
            }
            if (catalog.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck item in catalog.Trucks.OrderBy(truck => truck.Brand))
                {
                    Console.WriteLine($"{item.Brand}: {item.Model} - {item.Weight}kg");
                }
            }
        }
    }
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HP { get; set; }
    }
    class Catalog
    {
        public Catalog()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }
        public List<Car> Cars { get; }
        public List<Truck> Trucks { get; }
    }
}
