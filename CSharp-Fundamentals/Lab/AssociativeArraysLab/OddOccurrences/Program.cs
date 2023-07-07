using System;
using System.Collections.Generic;
using System.Linq;

namespace OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            string[] s = Console.ReadLine().Split();
            foreach (var item in s)
            {
                string lower = item.ToLower();
                if (dict.ContainsKey(lower))
                {
                    dict[lower]++;
                }
                else
                {
                    dict.Add(lower, 1);
                }
            }
            foreach (var item in dict)
            {
                if (item.Value % 2 != 0)
                {
                    Console.Write(item.Key + " ");
                }
            }
        }
    }
}
