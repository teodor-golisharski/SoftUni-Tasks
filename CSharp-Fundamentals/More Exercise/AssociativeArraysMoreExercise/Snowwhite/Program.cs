using System;
using System.Collections.Generic;
using System.Linq;

namespace Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            string input = Console.ReadLine();
            while (input != "Once upon a time")
            {
                string[] tokens = input.Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string hatColor = tokens[1];
                int physics = int.Parse(tokens[2]);
                string id = name + ":" + hatColor;
                
                if (!dict.ContainsKey(id))
                {
                    dict.Add(id, physics);
                }
                else
                {
                    dict[id] = Math.Max(dict[id], physics);
                }

                input = Console.ReadLine();
            }
            foreach (var item in dict.OrderByDescending(x => x.Value).ThenByDescending(x => dict.Where(y => y.Key.Split(':')[1] == x.Key.Split(':')[1]).Count()))
            {
                Console.WriteLine($"({item.Key.Split(':')[1]}) {item.Key.Split(':')[0]} <-> {item.Value}");
            }
        }
    }

}
