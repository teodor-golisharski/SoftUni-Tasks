using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string rate = Console.ReadLine();
            double price = 0;
            switch (room)
            {
                case "room for one person": price = 18; break;
                case "apartment":
                    price = 25;
                    if (days < 10)
                    {
                        price = price * 0.7;
                    }
                    if (days >= 10 && days <= 15)
                    {
                        price = price * 0.65;
                    }
                    if (days > 15)
                    {
                        price = price * 0.5;
                    }
                    break;
                case "president apartment":
                    price = 35;
                    if (days < 10)
                    {
                        price = price * 0.9;
                    }
                    if (days >= 10 && days <= 15)
                    {
                        price = price * 0.85;
                    }
                    if (days > 15)
                    {
                        price = price * 0.8;
                    }
                    break;
            }
            if (rate == "positive")
            {
                price = price * 1.25;
            }
            else if(rate == "negative")
            {
                price = price * 0.9;
            }

            Console.WriteLine($"{(price * (days - 1)):f2}");
        }
    }
}
