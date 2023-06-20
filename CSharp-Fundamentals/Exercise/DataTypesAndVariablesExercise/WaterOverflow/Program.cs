using System;

namespace WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                int q = int.Parse(Console.ReadLine());
                if (sum + q > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    sum += q;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
