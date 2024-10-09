using System;
using System.Linq;

namespace SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = n => int.Parse(n);
            int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToArray();
         
            Console.WriteLine(input.Length);
            Console.WriteLine(input.Sum());

            //string input = Console.ReadLine();
            //Console.WriteLine(String.Join(" ",
            //    input.Split(", ")
            //    .Select(int.Parse)
            //    .Count()));
            //Console.WriteLine(String.Join(" ",
            //    input.Split(", ")
            //    .Select(int.Parse)
            //    .Sum()));
        }
    }
}
