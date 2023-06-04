using System;

namespace MatchTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());
            double transport = 0;
            double ticketPrice = 0;
            if (people >= 1 && people <= 4)
            {
                transport = budget * 0.75;
            }
            else if (people >= 5 && people <= 9)
            {
                transport = budget * 0.6;
            }
            else if (people >= 10 && people <= 24)
            {
                transport = budget * 0.5;
            }
            else if (people >= 25 && people <= 49)
            {
                transport = budget * 0.4;
            }
            else if (people >= 50)
            {
                transport = budget * 0.25;
            }
            switch (s)
            {
                case "VIP": ticketPrice = 499.99;break;
                case "Normal": ticketPrice = 249.99;break;
            }
            double left = Math.Abs(budget - (ticketPrice * people + transport));
            if(ticketPrice*people+transport>budget)
            {
                Console.WriteLine($"Not enough money! You need {left:f2} leva.");
            }
            else if(ticketPrice * people + transport <= budget)
            {
                Console.WriteLine($"Yes! You have {left:f2} leva left.");
            }
        }
    }
}
