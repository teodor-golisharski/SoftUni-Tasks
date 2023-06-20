using System;

namespace Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int counter = 0;
            double orign = n * 0.50;
            while (n >= m)
            {
                if (n == orign)
                {
                    if (y > 0)
                    {
                        n /= y;
                        if (n < m)
                        {
                            break;
                        }
                    }
                }
                n -= m;
                counter++;


            }
            Console.WriteLine(n);
            Console.WriteLine(counter);
        }
    }
}
