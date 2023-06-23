using System;

namespace PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Triangle1(num);
            Triangle2(num);
        }
        static void PrintLine(int end)
        {
            for (int i = 1; i <= end; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        static void Triangle1(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                PrintLine(i);
            }
        }
        static void Triangle2(int num)
        {
            for (int j = num - 1; j >= 1; j--)
            {
                PrintLine(j);
            }
        }
    }
}
