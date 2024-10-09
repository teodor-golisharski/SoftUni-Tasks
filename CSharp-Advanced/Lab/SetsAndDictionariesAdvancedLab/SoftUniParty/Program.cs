using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            string input = Console.ReadLine();
            while (input != "PARTY")
            {
                set.Add(input);
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "END")
            {
                if(set.Contains(input))
                {
                    set.Remove(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(set.Count);
            foreach (var item in set.OrderByDescending(x => char.IsNumber(x[0]) == true))
            {
                Console.WriteLine(item);
            }
        }
    }
}
