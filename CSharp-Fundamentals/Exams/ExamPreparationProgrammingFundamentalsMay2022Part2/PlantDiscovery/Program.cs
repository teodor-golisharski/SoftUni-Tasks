using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> plantsRarity = new Dictionary<string, int>();
            Dictionary<string, List<int>> plantsRating = new Dictionary<string, List<int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split("<->");
                string plant = data[0];
                int rarity = int.Parse(data[1]);
                if (!plantsRarity.ContainsKey(plant))
                {
                    plantsRarity.Add(plant, rarity);
                    plantsRating.Add(plant, new List<int>());
                }
                else
                {
                    plantsRarity[plant] = rarity;
                }
            }
            string command = Console.ReadLine();
            while (command != "Exhibition")
            {
                string[] tokens = command.Split(": ");
                string mainCommand = tokens[0];
                string[] info = tokens[1].Split(" - ");
                string plant = info[0];
                if (!plantsRarity.ContainsKey(plant))
                {
                    Console.WriteLine("error");
                    command = Console.ReadLine();
                    continue;
                }
                switch (mainCommand)
                {
                    case "Rate":
                        int rating = int.Parse(info[1]);
                        plantsRating[plant].Add(rating);
                        break;

                    case "Update":
                        int newRarity = int.Parse(info[1]);
                        plantsRarity[plant] = newRarity;
                        break;

                    case "Reset":
                        plantsRating[plant].Clear();
                        break;

                }
                command = Console.ReadLine();
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in plantsRating)
            {
                if (item.Value.Count == 0)
                {
                    Console.WriteLine($"- {item.Key}; Rarity: {plantsRarity[item.Key]}; Rating: {0:f2}");
                }
                else
                {
                    Console.WriteLine($"- {item.Key}; Rarity: {plantsRarity[item.Key]}; Rating: {item.Value.Average():f2}");
                }
            }
        }
    }
}
