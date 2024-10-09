using System;
using System.Linq;

namespace MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                int[] array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = array[col];
                }
            }
            int maximal = int.MinValue;
            int indexRow = 0;
            int indexCol = 0;
            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int sum = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            sum += matrix[row + i, col + j];
                        }
                    }
                    if (sum > maximal)
                    {
                        maximal = sum;
                        indexRow = row;
                        indexCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maximal}");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[indexRow + i, indexCol + j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
