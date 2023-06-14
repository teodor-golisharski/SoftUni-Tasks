using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0;
            double result = 0;
            if (type == "Students")
            {
                switch (day)
                {
                    case "Friday": price = 8.45; break;
                    case "Saturday": price = 9.8; break;
                    case "Sunday": price = 10.46; break;
                }
                result = people * price;
                if (people >= 30)
                {
                    result = result * 0.85;
                }
            }
            else if (type == "Business")
            {
                switch (day)
                {
                    case "Friday": price = 10.9; break;
                    case "Saturday": price = 15.6; break;
                    case "Sunday": price = 16; break;
                }
                result = people * price;
                if (people >= 100)
                {
                    result = result - (10 * price);
                }
            }
            else if (type == "Regular")
            {
                switch (day)
                {
                    case "Friday": price = 15; break;
                    case "Saturday": price = 20; break;
                    case "Sunday": price = 22.5; break;
                }
                result = price * people;
                if (people >= 10 && people <= 20)
                {
                    result = result * 0.95;
                }
            }

            Console.WriteLine($"Total price: {result:f2}");
        }
    }
}
