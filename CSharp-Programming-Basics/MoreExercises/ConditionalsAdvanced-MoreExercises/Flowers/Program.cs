using System;

namespace Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            int chrysanthemum = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int tulips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            char ch = char.Parse(Console.ReadLine());
            double discount = 1;
            double discount2 = 1;
            double discount3 = 1;
            double discount4 = 1;
            double price1 = 0;
            double price2 = 0;
            double price3 = 0;
            double total = 0;
            if (ch == 'Y')
            {
                discount2 += 0.15;
            }
            if (ch == 'N')
            {
                discount2 = 1;
            }
            if (season == "Spring" || season == "Summer")
            {
                price1 = 2;
                price2 = 4.1;
                price3 = 2.5;
                if (tulips > 7 && season == "Spring")
                {
                    discount3 -= 0.05;
                }
            }
            if (season == "Autumn" || season == "Winter")
            {
                price1 = 3.75;
                price2 = 4.5;
                price3 = 4.15;
                if (season == "Winter" && roses >= 10)
                {
                    discount4 -= 0.1;
                }
            }
            if ((tulips + chrysanthemum + roses) > 20)
            {
                discount -= 0.2;
            }
            
            total = (chrysanthemum * price1 + roses * price2 + tulips * price3) * discount * discount2 * discount3 * discount4;
            Console.WriteLine($"{(total + 2):f2}");
        }
    }
}
