using System;
using System.Collections;

namespace TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                if (Property1(i) && Property2(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        static int DigSum(int i)
        {
            int sum = 0;
            while (i > 0)
            {
                sum += i % 10;
                i /= 10;
            }
            return sum;
        }
        static bool Property1(int i)
        {
            if (DigSum(i) % 8 == 0)
            {
                return true;
            }
            return false;
        }
        static bool Property2(int i)
        {
            while (i > 0)
            {
                if ((i % 10) % 2 != 0)
                {
                    return true;
                }
                i /= 10;
            }
            return false;
        }
    }
}
