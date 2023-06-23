using System;

namespace MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMultipleOfEvenAndOdds(n));
        }
        static int GetMultipleOfEvenAndOdds(int n)
        {
            return GetSumOfEvenDigits(n) * GetSumOfOddDigits(n);
        }
        static int GetSumOfEvenDigits(int n)
        {
            int sum = 0;
            int r = Math.Abs(n);
            while(r>0)
            {
                int last = r % 10;
                if(last%2==0)
                {
                    sum += last;
                }
                r /= 10;
            }
            return sum;
        }
        static int GetSumOfOddDigits(int n)
        {
            int sum = 0;
            int r = Math.Abs(n);
            while (r > 0)
            {
                int last = r % 10;
                if (last % 2 != 0)
                {
                    sum += last;
                }
                r /= 10;
            }
            return sum;
        }
    }
}
