using System;

namespace BracaletStand
{
    class Program
    {
        static void Main(string[] args)
        {
            double pocketMoney = double.Parse(Console.ReadLine());
            double dailyEarnings = double.Parse(Console.ReadLine());
            double expenses = double.Parse(Console.ReadLine());
            double presentPrize = double.Parse(Console.ReadLine());
            double earnedSaved = (5 * pocketMoney) + (5 * dailyEarnings);
            double withoutExpenses = earnedSaved - expenses;
            if (withoutExpenses >= presentPrize)
            {
                Console.WriteLine($"Profit: {withoutExpenses:f2} BGN, the gift has been purchased.");
            }
            else
            {
                double result = Math.Abs(withoutExpenses - presentPrize);
                Console.WriteLine($"Insufficient money: {result:f2} BGN.");
            }
        }
    }
}
