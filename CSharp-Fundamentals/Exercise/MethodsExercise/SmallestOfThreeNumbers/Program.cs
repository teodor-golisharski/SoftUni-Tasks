using System;

namespace SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine(Smallest(a,b,c));
        }
        static int Smallest(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }
    }
}
