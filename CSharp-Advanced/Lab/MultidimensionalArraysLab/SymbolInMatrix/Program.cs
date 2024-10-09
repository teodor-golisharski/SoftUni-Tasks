using System;

namespace SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] array = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string s = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    array[row, col] = s[col];
                }
            }
            char symbol = char.Parse(Console.ReadLine());
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if(array[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");return;
                    }
                }
            }
            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
