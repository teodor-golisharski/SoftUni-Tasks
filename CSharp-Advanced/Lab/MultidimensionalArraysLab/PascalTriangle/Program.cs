using System;
using System.Numerics;

namespace PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            BigInteger[][] jagged = new BigInteger[rows][];
            for (int row = 0; row < rows; row++)
            {
                jagged[row] = new BigInteger[row + 1];
                for (int col = 0; col < row + 1; col++)
                {
                    if (col == 0 || col == row)
                    {
                        jagged[row][col] = 1;
                    }
                    else
                    {
                        jagged[row][col] = jagged[row - 1][col] + jagged[row - 1][col - 1];
                    }
                }
            }
            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(jagged[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
