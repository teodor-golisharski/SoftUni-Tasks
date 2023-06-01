using System;

namespace Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double totalElCost = 0;
            double waterCost = 20;
            double wiFiCost = 15;
            double others = 0;
            double total = 0;

            for (int i = 1; i <= n; i++)
            {
                double elCost = double.Parse(Console.ReadLine());
                totalElCost += elCost;
                others += (waterCost + wiFiCost + elCost) * 1.2;
                
            }
            total = totalElCost + wiFiCost * n + waterCost * n + others;
            Console.WriteLine($"Electricity: {totalElCost:f2} lv");
            Console.WriteLine($"Water: {waterCost * n:f2} lv");
            Console.WriteLine($"Internet: {wiFiCost * n:f2} lv");
            Console.WriteLine($"Other: {others:f2} lv");
            Console.WriteLine($"Average: {total / n:f2} lv");
        }
    }
}
