using System;

namespace MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Method(a,n));
        }
        static double Method(int a, int n)
        {
            return Math.Pow(a, n);
        }
    }
}
