using System;

namespace Roadtrip
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string destination = "";
            double cost = 0;
            string acc = "";
            if (budget <= 100)
            {
                destination = "Bulgaria";
                switch (season)
                {
                    case "summer": cost = budget * 0.3; acc = "Camp"; break;
                    case "winter": cost = budget * 0.7; acc = "Hotel"; break;
                }
            }
            else if (budget > 100 && budget <= 1000)
            {
                destination = "Balkans";
                switch (season)
                {
                    case "summer": cost = budget * 0.4; acc = "Camp"; break;
                    case "winter": cost = budget * 0.8; acc = "Hotel"; break;
                }
            }
            else if (budget > 1000)
            {
                destination = "Europe";
                cost = budget * 0.9;
                acc = "Hotel";
            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{acc} - {cost:f2}");
        }
    }
}
