using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();
            
            string[] input = Console.ReadLine().Split();
            for (int i = 0; i < int.Parse(input[0]); i++)
            {
                first.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < int.Parse(input[1]); i++)
            {
                second.Add(int.Parse(Console.ReadLine()));
            }

            first.IntersectWith(second);
            Console.WriteLine(String.Join(" ", first));
        }
    }
}
