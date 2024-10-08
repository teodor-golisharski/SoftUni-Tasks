using System;
using System.Collections.Generic;

namespace Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> targetedCities = new Dictionary<string, List<int>>();
            string commands = Console.ReadLine();
            while (commands != "Sail")
            {
                string[] tokens = commands.Split("||");
                string cityName = tokens[0];
                int population = int.Parse(tokens[1]);
                int gold = int.Parse(tokens[2]);
                if (!targetedCities.ContainsKey(cityName))
                {
                    targetedCities.Add(cityName, new List<int>());
                    targetedCities[cityName].Add(population);
                    targetedCities[cityName].Add(gold);
                }
                else
                {
                    targetedCities[cityName][0] += population;
                    targetedCities[cityName][1] += gold;
                }
                commands = Console.ReadLine();
            }
            string events = Console.ReadLine();
            while (events != "End")
            {
                string[] command = events.Split("=>");
                string mainCommand = command[0];
                string city = command[1];
                switch (mainCommand)
                {
                    case "Plunder":
                        int people = int.Parse(command[2]);
                        int gold = int.Parse(command[3]);
                        targetedCities[city][0] -= people;
                        targetedCities[city][1] -= gold;
                        Console.WriteLine($"{city} plundered! {gold} gold stolen, {people} citizens killed.");
                        if (targetedCities[city][0] <= 0 || targetedCities[city][1] <= 0)
                        {
                            Console.WriteLine($"{city} has been wiped off the map!");
                            targetedCities.Remove(city);
                        }
                        break;

                    case "Prosper":
                        int additionalGold = int.Parse(command[2]);
                        if(additionalGold < 0)
                        {
                            Console.WriteLine($"Gold added cannot be a negative number!");
                        }
                        else
                        {
                            targetedCities[city][1] += additionalGold;
                            Console.WriteLine($"{additionalGold} gold added to the city treasury. {city} now has {targetedCities[city][1]} gold.");
                        }
                        break;
                }
                events = Console.ReadLine();
            }
            if(targetedCities.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {targetedCities.Count} wealthy settlements to go to:");
                foreach (var item in targetedCities)
                {
                    Console.WriteLine($"{item.Key} -> Population: {item.Value[0]} citizens, Gold: {item.Value[1]} kg");
                }
            }
        }
    }
}
