using System;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            double total = n * 250 + ((n * 250) * 0.35 * m) + ((n * 250) * 0.1 * p);
            
            if (n > m)
            {
                total = total * 0.85;
            }
            double left = Math.Abs(budget - total);
            if (total <= budget)
            {
                Console.WriteLine($"You have {left:f2} leva left!");
            }
            else if(total > budget)
            {
                Console.WriteLine($"Not enough money! You need {left:f2} leva more!");
            }
        }
    }
}
