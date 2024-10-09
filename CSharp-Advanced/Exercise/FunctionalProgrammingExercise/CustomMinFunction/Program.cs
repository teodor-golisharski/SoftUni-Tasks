using System;
using System.Linq;

namespace CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> func = x => x.Min();
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(func(numbers));
        }
    }
}
