using System;

namespace TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        char c1 = (char)(i + 97);
                        char c2 = (char)(j + 97);
                        char c3 = (char)(k + 97);
                        Console.WriteLine($"{c1}{c2}{c3}");
                    }
                }
            }
        }
    }
}
