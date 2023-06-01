using System;

namespace BackToThePast
{
    class Program
    {
        static void Main(string[] args)
        {
            double inheritance = double.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            double sum = 0;
            int spend = 0;
            for (int i = 1800; i <= year; i++)
            {
                if(i%2==0)
                {
                    spend = 12000;
                }
                else
                {
                    spend = 12000 + (50 * (18 + (i - 1800)));
                }
                sum += spend;
            }
            if(sum<=inheritance)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {Math.Abs(sum-inheritance):f2} dollars left.");
            }
            else if(sum>inheritance)
            {
                Console.WriteLine($"He will need {Math.Abs(sum - inheritance):f2} dollars to survive.");
            }
        }
    }
}
