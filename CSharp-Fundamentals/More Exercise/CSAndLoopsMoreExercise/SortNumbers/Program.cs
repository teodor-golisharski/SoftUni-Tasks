using System;

namespace SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double temp = 0;
            while (true)
            {
                if (a < b)
                {
                    temp = a;
                    a = b;
                    b = temp;
                    temp = 0;
                }
                if (b < c)
                {
                    temp = b;
                    b = c;
                    c = temp;
                    temp = 0;
                }
                if (a < c)
                {
                    temp = a;
                    a = c;
                    c = temp;
                    temp = 0;
                }
                if (a >= b && b >= c)
                {
                    Console.WriteLine(a);
                    Console.WriteLine(b);
                    Console.WriteLine(c);
                    return;
                }
            }
        }
    }
}
