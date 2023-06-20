using System;

namespace StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = n;
            int res = 1;
            int sum = 0;
            while (n >= 1)
            {
                
                for (int i = 1; i <= n % 10; i++)
                {
                    res *= i;
                }
                sum += res;
                res = 1;
                n = n / 10;
            }
            if (sum == num)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}
