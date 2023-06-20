using System;
using System.Numerics;

namespace Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger max = 0;
            int max1 = 0, max2 = 0, max3 = 0;
            for (int i = 1; i <= n; i++)
            {
                int snowball = int.Parse(Console.ReadLine());
                int time = int.Parse(Console.ReadLine());
                int quality = int.Parse(Console.ReadLine());
                BigInteger value = BigInteger.Pow(snowball / time, quality);
                if (value > max)
                {
                    max = value;
                    max1 = snowball;
                    max2 = time;
                    max3 = quality;
                }
            }
            Console.WriteLine($"{max1} : {max2} = {max} ({max3})");
        }
    }
}
