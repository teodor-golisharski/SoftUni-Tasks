using System;

namespace SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int prime = 0;
            int nonPrime = 0;
            int n;
            bool isPrime;
            while (input != "stop")
            {

                n = int.Parse(input);
                if (n < 0)
                {
                    Console.WriteLine("Number is negative.");
                    input = Console.ReadLine();
                    continue;
                }
                isPrime = true;
                for (int i = 2; i <= n - 1; i++)
                {
                    if (n % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    prime += n;
                }
                else
                {
                    nonPrime += n;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {prime}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrime}");
        }



    }
}
