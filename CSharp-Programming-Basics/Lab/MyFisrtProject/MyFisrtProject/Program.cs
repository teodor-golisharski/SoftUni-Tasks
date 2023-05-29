using System;

namespace MyFisrtProject
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            if (n >= 26 && n <= 35) Console.WriteLine("Hot");
            else
            if (n >= 20.1 && n <= 25.9) Console.WriteLine("Warm");
            else
            if (n >= 15 && n <= 20) Console.WriteLine("Mild");
            else
            if (n >= 12 && n <= 14.9) Console.WriteLine("Cool");
            else
            if (n >= 5 && n <= 11.9) Console.WriteLine("Cold");
            else
                Console.WriteLine("unknown");
        }
    }
}
