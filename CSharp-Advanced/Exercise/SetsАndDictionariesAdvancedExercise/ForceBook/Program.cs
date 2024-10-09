using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedSet<string>> forceUsers = new Dictionary<string, SortedSet<string>>();

            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                if (input.Contains('|'))
                {
                    string[] tokens = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string side = tokens[0];
                    string name = tokens[1];

                    if (!forceUsers.Values.Any(x => x.Contains(name)))
                    {
                        if (!forceUsers.ContainsKey(side))
                        {
                            forceUsers.Add(side, new SortedSet<string>());
                        }
                        forceUsers[side].Add(name);
                    }
                }
                else
                {
                    string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string name = tokens[0];
                    string side = tokens[1];

                    foreach (var item in forceUsers)
                    {
                        if(item.Value.Contains(name))
                        {
                            item.Value.Remove(name);
                            break;
                        }
                    }

                    if(!forceUsers.ContainsKey(side))
                    {
                        forceUsers.Add(side, new SortedSet<string>());
                    }
                    forceUsers[side].Add(name);

                    Console.WriteLine($"{name} joins the {side} side!");
                }
                input = Console.ReadLine();
            }
            foreach (var sides in forceUsers.OrderByDescending(x => x.Value.Count()).ThenBy(x => x.Key))
            {
                if (sides.Value.Count() > 0)
                {
                    Console.WriteLine($"Side: {sides.Key}, Members: {sides.Value.Count}");
                }
                foreach (var item in sides.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {item}");
                }
            }
        }
    }
}
