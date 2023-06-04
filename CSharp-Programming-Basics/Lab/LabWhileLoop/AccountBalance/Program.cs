using System;

namespace AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double total = 0.0;
            while (input != "NoMoreMoney")
            {
                double inc = double.Parse(input);
                if (inc < 0)
                {
                    Console.WriteLine("Invalid operation!");break;
                }
                total += inc;
                Console.WriteLine($"Increase: {inc:f2}");
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total: {total:f2}");
        }
    }
}
