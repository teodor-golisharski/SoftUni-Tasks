using System;
using System.Collections.Generic;
using System.Linq;

namespace Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>(Console.ReadLine().Split().Select(x => int.Parse(x)).ToList());
            int[] sorted = numbers.OrderByDescending(x => x).ToArray();
            if(numbers.Count >= 3)
            {
                Console.WriteLine($"{sorted[0]} {sorted[1]} {sorted[2]}");
            }
            else
            {
                Console.WriteLine(String.Join(" ", sorted));
            }
        }
    }
}
