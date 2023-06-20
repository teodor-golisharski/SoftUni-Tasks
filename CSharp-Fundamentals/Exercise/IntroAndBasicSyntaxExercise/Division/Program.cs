using System;

namespace Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int div = 0;
            int[] pr = { 2, 3, 6, 7, 10 };
            for (int i = 0; i < pr.Length; i++)
            {
                if (num % pr[i] == 0) 
                {
                    div = pr[i];
                }
            }
            if (div != 0)
            {
                Console.WriteLine($"The number is divisible by {div}");
            }
            else
            {
                Console.WriteLine("Not divisible");
            }
        }
    }
}
