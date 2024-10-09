using System;
using System.Linq;

namespace SortEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(", ", 
            Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToArray()));
        }
    }
}
