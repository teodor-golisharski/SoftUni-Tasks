using System;
using System.Collections.Generic;

namespace CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> map = new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string continent = data[0];
                string country = data[1];
                string city = data[2];
                if (!map.ContainsKey(continent))
                {
                    map[continent] = new Dictionary<string, List<string>>();
                    map[continent].Add(country, new List<string> { city });
                }
                else
                {
                    if (!map[continent].ContainsKey(country))
                    {
                        map[continent].Add(country, new List<string> { city });
                    }
                    else
                    {
                        map[continent][country].Add(city);
                    }
                }
            }
            foreach (var cont in map)
            {
                Console.WriteLine($"{cont.Key}:");
                foreach (var item in cont.Value)
                {
                    Console.WriteLine($"    {item.Key} -> {string.Join(", ", item.Value)}");
                }
            }
        }
    }
}
