using System;

namespace SignOfIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Check(num);
        }
        static void Check(int num)
        {
            string status = string.Empty;
            if (num > 0)
            {
                status = "positive";
            }
            else if (num < 0)
            {
                status = "negative";
            }
            else
            {
                status = "zero";
            }
            Console.WriteLine($"The number {num} is {status}.");
        }
    }
}
