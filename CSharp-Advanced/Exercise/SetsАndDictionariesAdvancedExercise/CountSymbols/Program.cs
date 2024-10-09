using System;
using System.Collections.Generic;

namespace CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> dictionary = new SortedDictionary<char, int>();
            string text = Console.ReadLine();
            foreach (var item in text)
            {
                if(!dictionary.ContainsKey(item))
                {
                    dictionary.Add(item, 1);
                }
                else
                {
                    dictionary[item]++;
                }
            }
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
