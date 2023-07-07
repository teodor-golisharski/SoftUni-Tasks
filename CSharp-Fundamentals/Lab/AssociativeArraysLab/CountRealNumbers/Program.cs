using System;
using System.Collections.Generic;
using System.Linq;

namespace CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<int, int> occurencesByNumber = new SortedDictionary<int, int>();
            int[] num = Console.ReadLine().Split().Select(int.Parse).ToArray();
            foreach (var item in num)
            {
                if (occurencesByNumber.ContainsKey(item))
                {
                    occurencesByNumber[item]++;
                }
                else
                {
                    occurencesByNumber.Add(item, 1);
                }
            }
            foreach (var item in occurencesByNumber)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
