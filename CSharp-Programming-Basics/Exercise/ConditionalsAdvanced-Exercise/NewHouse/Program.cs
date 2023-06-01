using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = 0;
            if (flower == "Roses")
            {
                if (num > 80) price = 5 * 0.9;
                else if (num <= 80) price = 5;
            }
            if (flower == "Dahlias")
            {
                if (num > 90) price = 3.8 * 0.85;
                else if (num <= 90) price = 3.8;
            }
            if (flower == "Tulips")
            {
                if (num > 80) price = 2.8 * 0.85;
                else if (num <= 80) price = 2.8;
            }
            if (flower == "Narcissus")
            {
                if (num < 120) price = 3 * 1.15;
                else if (num >= 120) price = 3;
            }
            if (flower == "Gladiolus")
            {
                if (num < 80) price = 2.5 * 1.2;
                else if (num >= 80) price = 2.5;
            }
            double left = (Math.Abs(budget - (num * price)));
            if (budget >= (num * price))
            {
                Console.WriteLine($"Hey, you have a great garden with {num} {flower} and {left:f2} leva left.");
            }
            else if (budget < (num * price))
            {
                Console.WriteLine($"Not enough money, you need {left:f2} leva more.");
            }
        }
    }
}
