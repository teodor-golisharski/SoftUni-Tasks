using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                foreach (var item in input)
                {
                    set.Add(item);
                }
            }
            Console.WriteLine(string.Join(" ", set.OrderBy(x => x)));
        }
    }
}
