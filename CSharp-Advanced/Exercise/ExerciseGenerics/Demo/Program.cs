using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> binary = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                char currentSymbol = input[i];
                binary.Add(int.Parse(currentSymbol.ToString()));
            }
            binary.Sort();
            binary.Reverse();
            Console.WriteLine(string.Join("", binary));


            Console.WriteLine("Ti si smotan");
            Console.WriteLine("Ti si smotan");
            Console.WriteLine("Ti si smotan");
            Console.WriteLine("Ti si smotan");
            Console.WriteLine("Ti si smotan");
            Console.WriteLine("Ti si smotan");
            Console.WriteLine("Ti si smotan");
            Console.WriteLine("Ti si smotan");
            Console.WriteLine("Ti si smotan");
            Console.WriteLine("Ti si smotan");

        }
    }
}
