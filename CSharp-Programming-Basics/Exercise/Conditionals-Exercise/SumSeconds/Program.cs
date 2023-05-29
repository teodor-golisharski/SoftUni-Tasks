using System;

namespace SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            int totalTime = first + second + third;
            int m = totalTime / 60;
            int s = totalTime % 60;
            if (s < 10)
            {
                Console.WriteLine($"{m}:0{s}");
            }
            else
            {
                Console.WriteLine($"{m}:{s}");
            }
        }
    }
}
