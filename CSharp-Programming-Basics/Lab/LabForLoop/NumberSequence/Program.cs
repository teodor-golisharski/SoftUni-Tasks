using System;

namespace NumberSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int min = int.MaxValue;
            int max = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num > max) max = num;
                if (num < min) min = num;
            }
            Console.WriteLine("Max number: " + max);
            Console.WriteLine("Min number: " + min);
        }
    }
}
