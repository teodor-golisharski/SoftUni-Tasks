using System;

namespace AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine(Subtract(Sum(a, b), c));
        }
        static int Sum(int a, int b)
        {
            return a + b;
        }
        static int Subtract(int s, int c)
        {
            return s - c;
        }
    }
}
