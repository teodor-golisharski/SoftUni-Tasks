using System;

namespace LunchBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            string series = Console.ReadLine();
            int ep = int.Parse(Console.ReadLine());
            double lunch = double.Parse(Console.ReadLine());
            double lunchTime = lunch * 1 / 8;
            double restTime = lunch * 1 / 4;
            double leftTime = lunch - lunchTime - restTime;
            
            double left = Math.Ceiling(Math.Abs(leftTime - ep));
            if(ep<=leftTime)
            {
                Console.WriteLine($"You have enough time to watch {series} and left with {left} minutes free time.");
            }
            else if(ep>leftTime)
            {
                Console.WriteLine($"You don't have enough time to watch {series}, you need {left} more minutes.");
            }
        }
    }
}
