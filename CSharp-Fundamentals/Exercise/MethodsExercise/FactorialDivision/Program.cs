using System;

namespace FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"{Factorial(a)/Factorial(b):f2}");
        }
        static double Factorial(int a)
        {
            double sum = 1;
            for (int i = a; i >=1; i--)
            {
                sum *= i;
            }
            return sum;
        }
    }
}
