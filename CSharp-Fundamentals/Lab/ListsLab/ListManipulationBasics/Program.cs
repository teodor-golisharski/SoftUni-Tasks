using System;
using System.Linq;
using System.Collections.Generic;

namespace ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] input = Console.ReadLine().Split();
            while (input[0] != "end")
            {
                switch (input[0])
                {
                    case "Add": numbers.Add(int.Parse(input[1]));break;
                    case "Remove":numbers.Remove(int.Parse(input[1]));break;
                    case "RemoveAt":numbers.RemoveAt(int.Parse(input[1]));break;
                    case "Insert":numbers.Insert(int.Parse(input[2]), int.Parse(input[1]));break;
                }
                input = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
