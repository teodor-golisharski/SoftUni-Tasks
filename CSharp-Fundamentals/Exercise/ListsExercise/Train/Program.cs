using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int capacity = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split();
            while (input[0] != "end")
            {
                if (input[0] == "Add")
                {
                    wagons.Add(int.Parse(input[1]));
                }
                else
                {
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (int.Parse(input[0]) + wagons[i] <= capacity)
                        {
                            wagons[i] += int.Parse(input[0]); break;
                        }
                    }
                }
                input = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
