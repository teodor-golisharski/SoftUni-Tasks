using System;

namespace PoundsToDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double result = num * 1.31;
            Console.WriteLine($"{result:f3}");

        }
    }
}
