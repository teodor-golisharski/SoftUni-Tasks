using System;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine($"{Product(s)*num:f2}");
        }
        static double Product(string s)
        {
            double price = 0;
            switch (s)
            {
                case "coffee": price = 1.5;break;
                case "water": price = 1; break;
                case "coke": price = 1.4; break;
                case "snacks": price = 2; break;
            }
            return price;
        }
    }
}
