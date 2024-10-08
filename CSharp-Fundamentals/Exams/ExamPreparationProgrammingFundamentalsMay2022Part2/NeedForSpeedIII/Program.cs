using System;
using System.Collections.Generic;

namespace NeedForSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> carsCollection = new Dictionary<string, List<int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split('|');
                string car = input[0];
                int mileage = int.Parse(input[1]); 
                int fuel = int.Parse(input[2]); 
                carsCollection.Add(car, new List<int>());
                carsCollection[car].Add(mileage);
                carsCollection[car].Add(fuel);
            }
            string commands = Console.ReadLine();
            string mainCommand = string.Empty;
            string carModel = string.Empty;
            while(commands != "Stop")
            {
                string[] tokens = commands.Split(" : ");
                mainCommand = tokens[0];
                carModel = tokens[1];
                switch (mainCommand)
                {
                    case "Drive":
                        int distance = int.Parse(tokens[2]);
                        int fuelNeeded = int.Parse(tokens[3]);
                        if(carsCollection[carModel][1] >= fuelNeeded)
                        {
                            carsCollection[carModel][0] += distance;
                            carsCollection[carModel][1] -= fuelNeeded;
                            Console.WriteLine($"{carModel} driven for {distance} kilometers. {fuelNeeded} liters of fuel consumed.");
                            if(carsCollection[carModel][0]>=100000)
                            {
                                carsCollection.Remove(carModel);
                                Console.WriteLine($"Time to sell the {carModel}!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }
                        break;

                    case "Refuel":
                        int fuel = int.Parse(tokens[2]);
                        if(carsCollection[carModel][1] + fuel <= 75)
                        {
                            carsCollection[carModel][1] += fuel;
                        }
                        else
                        {
                            fuel = 75 - carsCollection[carModel][1];
                            carsCollection[carModel][1] = 75;
                        }
                        Console.WriteLine($"{carModel} refueled with {fuel} liters");
                        break;

                    case "Revert":
                        int kilometers = int.Parse(tokens[2]);
                        if(carsCollection[carModel][0] - kilometers >= 10000)
                        {
                            carsCollection[carModel][0] -= kilometers;
                            Console.WriteLine($"{carModel} mileage decreased by {kilometers} kilometers");
                        }
                        else
                        {
                            carsCollection[carModel][0] = 10000;
                        }
                        break;
                }
                commands = Console.ReadLine();
            }
            foreach (var item in carsCollection)
            {
                Console.WriteLine($"{item.Key} -> Mileage: {item.Value[0]} kms, Fuel in the tank: {item.Value[1]} lt.");
            }
        }
    }
}
