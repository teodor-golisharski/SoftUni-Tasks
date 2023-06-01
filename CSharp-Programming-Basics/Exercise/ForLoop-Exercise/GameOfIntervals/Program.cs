using System;

namespace GameOfIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double points1 = 0;
            double points2 = 0;
            double points3 = 0;
            double points4 = 0;
            double points5 = 0;
            double points6 = 0;
            double result = 0;
            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num >= 0 && num <= 9)
                {
                    points1++;
                    result += num * 0.2;
                }
                else if (num >= 10 && num <= 19)
                {
                    points2++;
                    result += num * 0.3;
                }
                else if (num >= 20 && num <= 29)
                {
                    points3++;
                    result += num * 0.4;
                }
                else if (num >= 30 && num <= 39)
                {
                    points4++;
                    result += 50;
                }
                else if (num >= 40 && num <= 50)
                {
                    points5++;
                    result += 100;
                }
                else
                {
                    points6++;
                    result = result / 2;
                }
            }
            Console.WriteLine($"{result:f2}");
            Console.WriteLine($"From 0 to 9: {points1/n*100:f2}%");
            Console.WriteLine($"From 10 to 19: {points2/n*100:f2}%");
            Console.WriteLine($"From 20 to 29: {points3/n*100:f2}%");
            Console.WriteLine($"From 30 to 39: {points4/n*100:f2}%");
            Console.WriteLine($"From 40 to 50: {points5/n*100:f2}%");
            Console.WriteLine($"Invalid numbers: {points6/n*100:f2}%");
        }
    }
}
