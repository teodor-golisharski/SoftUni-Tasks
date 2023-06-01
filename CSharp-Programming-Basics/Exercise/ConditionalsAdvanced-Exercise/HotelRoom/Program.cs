using System;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            double priceS = 0;
            double priceA = 0;
            string acc1 = "";
            string acc2 = "";
            switch (month)
            {
                case "May":
                case "October":
                    priceS = 50;
                    priceA = 65;
                    if (days > 7 && days <=14)
                    {
                        priceS = priceS * 0.95;
                    }
                    else if (days > 14)
                    {
                        priceS = priceS * 0.7;
                        priceA = priceA * 0.9;
                    }
                    break;
                case "June":
                case "September":
                    priceS = 75.2;
                    priceA = 68.7;
                    if (days > 14)
                    {
                        priceS = priceS * 0.8;
                        priceA = priceA * 0.9;
                    }
                    break;
                case "July":
                case "August":
                    priceS = 76;
                    priceA = 77;
                    if(days>14)
                    {
                        priceA = priceA * 0.9;
                    }
                    break;
            }
            Console.WriteLine($"Apartment: {days*priceA:f2} lv.");
            Console.WriteLine($"Studio: {days*priceS:f2} lv.");
        }
    }
}
