using System;

namespace NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Matrix(n);
        }
        static void Matrix(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(Line(n));
            }
        }
        static string Line(int n)
        {
            string s = string.Empty;
            for (int i = 1; i <= n; i++)
            {
                s += n + " ";
            }
            return s;
        }
    }
}
