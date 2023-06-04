using System;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            int coins = 0;
            while (change > 0)
            {
                if (change >= 2)
                {
                    change = Math.Round(change - 2, 2);
                    coins++;
                    continue;
                }
                if (change >= 1)
                {
                    change = Math.Round(change - 1, 2);
                    coins++;
                    continue;
                }
                if (change >= 0.5)
                {
                    change = Math.Round(change - 0.5, 2);
                    coins++;
                    continue;
                }
                if (change >= 0.2)
                {
                    change = Math.Round(change - 0.2, 2);
                    coins++;
                    continue;
                }
                if (change >= 0.10)
                {
                    change = Math.Round(change - 0.1, 2);
                    coins++;
                    continue;
                }
                if (change >= 0.05)
                {
                    change = Math.Round(change - 0.05, 2);
                    coins++;
                    continue;
                }
                if (change >= 0.02)
                {
                    change = Math.Round(change - 0.02, 2);
                    coins++;
                    continue;
                }
                if (change >= 0.01)
                {
                    change = Math.Round(change - 0.01, 2);
                    coins++;
                    continue;
                }
            }
            Console.WriteLine(coins);
        }
    }
}
