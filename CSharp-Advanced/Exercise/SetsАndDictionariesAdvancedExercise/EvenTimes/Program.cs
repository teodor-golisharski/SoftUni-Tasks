using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse((Console.ReadLine()));
                if (!dict.ContainsKey(number))
                {
                    dict.Add(number, 1);
                }
                else
                {
                    dict[number]++;
                }
            }
            foreach (var item in dict)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
