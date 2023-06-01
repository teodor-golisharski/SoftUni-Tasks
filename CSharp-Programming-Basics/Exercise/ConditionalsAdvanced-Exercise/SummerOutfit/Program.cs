using System;

namespace SummerOutfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int temp = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();
            string outfit = "";
            string shoes = "";
            if(time == "Morning")
            {
                if(temp>=10&&temp<=18)
                {
                    shoes = "Sneakers";
                    outfit = "Sweatshirt";
                }
                else if (temp > 18 && temp <= 24)
                {
                    shoes = "Moccasins";
                    outfit = "Shirt";
                }
                else if (temp >= 25)
                {
                    shoes = "Sandals";
                    outfit = "T-Shirt";
                }
            }
            if (time == "Afternoon")
            {
                if (temp >= 10 && temp <= 18)
                {
                    shoes = "Moccasins";
                    outfit = "Shirt";
                }
                else if (temp > 18 && temp <= 24)
                {
                    shoes = "Sandals";
                    outfit = "T-Shirt";
                }
                else if (temp >= 25)
                {
                    shoes = "Barefoot";
                    outfit = "Swim Suit";
                }
            }
            if (time == "Evening")
            {
                if (temp >= 10 && temp <= 18)
                {
                    shoes = "Moccasins";
                    outfit = "Shirt";
                }
                else if (temp > 18 && temp <= 24)
                {
                    shoes = "Moccasins";
                    outfit = "Shirt";
                }
                else if (temp >= 25)
                {
                    shoes = "Moccasins";
                    outfit = "Shirt";
                }
            }
            Console.WriteLine($"It's {temp} degrees, get your {outfit} and {shoes}.");
        }
    }
}
