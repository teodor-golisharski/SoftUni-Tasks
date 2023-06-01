using System;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double total1 = 0;
            double total2 = 0;
            double total3 = 0;
            double total4 = 0;
            double total5 = 0;
            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < 200)
                {
                    total1++;
                }
                else if (num >= 200 && num <= 399)
                {
                    total2++;
                }
                else if (num >= 400 && num <= 599)
                {
                    total3++;
                }
                else if (num >= 600 && num <= 799)
                {
                    total4++;
                }
                else if (num >= 800)
                {
                    total5++;
                }
            }
            double sum = total1 + total2 + total3 + total4 + total5;
            Console.WriteLine($"{(total1/sum*100):f2}%");
            Console.WriteLine($"{(total2/sum*100):f2}%");
            Console.WriteLine($"{(total3/sum*100):f2}%");
            Console.WriteLine($"{(total4/sum*100):f2}%");
            Console.WriteLine($"{(total5/sum*100):f2}%");
        }
    }
}
