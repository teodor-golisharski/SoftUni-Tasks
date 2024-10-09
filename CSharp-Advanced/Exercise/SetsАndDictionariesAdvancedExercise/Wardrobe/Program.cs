using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dictionary = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string color = input[0];
                string[] clothes = input[1].Split(',');
                if (!dictionary.ContainsKey(color))
                {
                    dictionary.Add(color, new Dictionary<string, int>());
                }
                foreach (var item in clothes)
                {
                    if (!dictionary[color].ContainsKey(item))
                    {
                        dictionary[color].Add(item, 1);
                    }
                    else
                    {
                        dictionary[color][item]++;
                    }
                }
            }
            string[] clothesToSearch = Console.ReadLine().Split();
            string searchingColor = clothesToSearch[0];
            string searchingClothes = clothesToSearch[1];
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var temps in item.Value)
                {
                    if (temps.Key == searchingClothes && item.Key == searchingColor)
                    {
                        Console.WriteLine($"* {temps.Key} - {temps.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {temps.Key} - {temps.Value}");
                    }
                }
            }
        }
    }
}
