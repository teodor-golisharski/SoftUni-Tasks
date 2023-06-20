using System;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double total = 0;
            for (int i = 1; i <= n; i++)
            {
                double capsPrice = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsCount = int.Parse(Console.ReadLine());
                total += capsCount * capsPrice * days;
                Console.WriteLine($"The price for the coffee is: ${capsCount * capsPrice * days:f2}");
            }
            Console.WriteLine($"Total: ${total:f2}");
        }
    }
}
