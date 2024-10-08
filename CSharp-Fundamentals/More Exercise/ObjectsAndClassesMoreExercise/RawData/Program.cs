using System;
using System.Collections.Generic;

namespace RawData
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
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Car car = new Car(model, engine, cargo);
                cars.Add(car);
            }
            string command = Console.ReadLine();
            if(command == "fragile")
            {
                Fragile(cars);
            }
            else if(command == "flamable")
            {
                Flamable(cars);
            }
        }
        static void Fragile(List<Car> cars)
        {
            foreach (var item in cars)
            {
                if(item.Cargo.CargoType == "fragile" && item.Cargo.CargoWeight < 1000)
                {
                    Console.WriteLine(item.Model);
                }
            }
        }
        static void Flamable(List<Car> cars)
        {
            foreach (var item in cars)
            {
                if (item.Cargo.CargoType == "flamable" && item.Engine.Power > 250)
                {
                    Console.WriteLine(item.Model);
                }
            }
        }
    }

    class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
    }
    class Engine
    {
        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }
        public int Speed { get; set; }
        public int Power { get; set; }
    }

    class Cargo
    {
        public Cargo(int cargoWeight, string cargoType)
        {
            CargoWeight = cargoWeight;
            CargoType = cargoType;
        }
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
    }

}
