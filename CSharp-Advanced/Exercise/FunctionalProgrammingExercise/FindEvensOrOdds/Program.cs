using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<int> list = new List<int>();
            List<int> result = new List<int>();
            int[] range = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            string type = Console.ReadLine();
            
            for (int i = range[0]; i <= range[1]; i++)
            {
                list.Add(i);
            }

            Predicate<int> even = x => x % 2 == 0;
            Predicate<int> odd = x => x % 2 != 0;
            
            if(type == "even")
            {
                result = list.FindAll(even);
            }
            else
            {
                result = list.FindAll(odd);
            }

            Console.WriteLine(string.Join(" ", result));


        }
    }
}
