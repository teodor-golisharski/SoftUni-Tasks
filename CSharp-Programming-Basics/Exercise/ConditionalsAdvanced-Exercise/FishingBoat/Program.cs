using System;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishers = int.Parse(Console.ReadLine());
            double rent = 0;
            double discount1 = 0;
            switch (season)
            {
                case "Spring": rent = 3000; break;
                case "Summer": case "Autumn": rent = 4200; break;
                case "Winter": rent = 2600; break;
            }
            if (fishers <= 6) discount1 = 0.1;
            else if (fishers >= 7 && fishers <= 11) discount1 = 0.15;
            else if (fishers > 12) discount1 = 0.25;
            double result = rent * (1 - discount1);
            if (fishers % 2 == 0 && season != "Autumn") result = result * 0.95;
            double left = Math.Abs(budget - result);
            if (budget >= result)
            {
                Console.WriteLine($"Yes! You have {left:f2} leva left.");
            }
            else if(result>budget)
            {
                Console.WriteLine($"Not enough money! You need {left:f2} leva.");
            }

        }
    }
}
