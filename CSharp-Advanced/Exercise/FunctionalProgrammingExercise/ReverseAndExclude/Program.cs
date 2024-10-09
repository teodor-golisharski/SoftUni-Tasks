using System;
using System.Linq;

namespace ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToArray();

            int divison = int.Parse(Console.ReadLine());

            Console.WriteLine(String.Join(" ", numbers.Where(x => x % divison != 0)));
        }
    }
}
