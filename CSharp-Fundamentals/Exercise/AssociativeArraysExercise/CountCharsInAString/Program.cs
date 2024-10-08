using System;
using System.Collections.Generic;
using System.Linq;

namespace CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string seq = Console.ReadLine();
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char item in seq)
            {
                if (item != ' ')
                {
                    if (dict.ContainsKey(item))
                    {
                        dict[item]++;
                    }
                    else
                    {
                        dict[item] = 1;
                    }
                }
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
