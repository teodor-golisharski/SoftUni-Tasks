using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> dict = new Dictionary<double, int>();
            double[] array = Console.ReadLine().Split().Select(double.Parse).ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (!dict.ContainsKey(array[i]))
                {
                    dict.Add(array[i], 1);
                }
                else
                {
                    dict[array[i]]++;
                }
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
