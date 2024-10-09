using System;
using System.Linq;
using System.Net.Http.Headers;

namespace AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<decimal, decimal> afterTax = x => x * 1.2M;
            decimal[] array = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .Select(afterTax)
                .ToArray();

            Console.WriteLine(String.Join(Environment.NewLine, array));
        }
    }
}
