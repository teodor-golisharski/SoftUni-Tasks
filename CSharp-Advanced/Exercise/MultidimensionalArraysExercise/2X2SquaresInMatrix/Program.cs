using System;
using System.Linq;

namespace _2X2SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];
            char[,] matrix = new char[rows, cols];
            int sum = 0;
            for (int row = 0; row < rows; row++)
            {
                char[] array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = array[col];
                }
            }
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row, col] == matrix[row + 1, col] && matrix[row, col] == matrix[row, col + 1] && matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        sum++;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
