using System;

namespace BonusPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            double b = 0;
            if (n % 2 == 0) b += 1;
            if (n % 10 == 5) b += 2;
            if (n <= 100)
            {
                b += 5;
            }
            else if(n>100&&n<=1000)
            {
                b = b + (n * 20/100);
            }
            else if (n > 1000) 
            {
                b = b + (n * 10 / 100);
            }
            Console.WriteLine(b);
            Console.WriteLine(n+b);
        }
    }
}
