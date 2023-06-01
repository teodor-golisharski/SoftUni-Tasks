using System;

namespace EqualPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double diff = 0;
            double sum = 0;
            double maxDiff = 0;
            for (int i = 0; i < n; i++)
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                double currentSum = a + b;
                if (i == 0)
                {
                    sum = currentSum;
                }
                else
                {
                    diff = Math.Abs(sum - currentSum);
                    sum = currentSum;
                }
                if (diff > maxDiff)
                {
                    maxDiff = diff;
                }
            }
            if (maxDiff == 0)
            {
                Console.WriteLine("Yes, value=" + sum);
            }
            else
            {
                Console.WriteLine("No, maxdiff=" + maxDiff);
            }
        }
    }
}
