using System;

namespace BikeRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int juniors = int.Parse(Console.ReadLine());
            int seniors = int.Parse(Console.ReadLine());
            string trail = Console.ReadLine();
            int totalcomp = juniors + seniors;
            double juniorTax = 0;
            double seniorTax = 0;
            double discount = 1;
            switch (trail)
            {
                case "trail": juniorTax = 5.5; seniorTax = 7; break;
                case "cross-country": juniorTax = 8; seniorTax = 9.5; break;
                case "downhill": juniorTax = 12.25; seniorTax = 13.75; break;
                case "road": juniorTax = 20; seniorTax = 21.5; break;
            }
            if (trail == "cross-country" && totalcomp >= 50)
            {
                discount = 0.75;
            }
            double result = (juniors * juniorTax + seniors * seniorTax) * 0.95 * discount;
            Console.WriteLine($"{result:f2}");
        }
    }
}
