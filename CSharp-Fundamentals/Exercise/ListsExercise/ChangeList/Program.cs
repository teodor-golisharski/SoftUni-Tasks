using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] input = Console.ReadLine().Split();
            while (input[0] != "end")
            {
                switch (input[0])
                {
                    case "Delete":
                        integers.RemoveAll(el => el == int.Parse(input[1]));
                        break;
                    case "Insert":
                        integers.Insert(int.Parse(input[2]), int.Parse(input[1]));
                        break;
                }
                input = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", integers));
        }
    }
}
