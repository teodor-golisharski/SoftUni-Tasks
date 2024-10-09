using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            Lake lake = new Lake(list);
            Console.WriteLine(String.Join(", ", lake));
        }
    }
}
