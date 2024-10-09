using System;

namespace SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sizes = Console.ReadLine().Split(", ");
            int rows = int.Parse(sizes[0]);
            int cols = int.Parse(sizes[1]);
            int[,] array = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string[] elements = Console.ReadLine().Split(", ");
                for (int col = 0; col < cols; col++)
                {
                    array[row, col] = int.Parse(elements[col]);
                }
            }
            int maxSum = int.MinValue;
            int[,] submatrix = new int[2, 2];
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int a = array[row, col];
                    int b = array[row + 1, col];
                    int c = array[row, col + 1];
                    int d = array[row + 1, col + 1];
                    if (a + b + c + d > maxSum)
                    {
                        maxSum = a + b + c + d;
                        submatrix[0, 0] = a;
                        submatrix[0, 1] = c;
                        submatrix[1, 0] = b;
                        submatrix[1, 1] = d;
                    }
                }
            }
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; i < 2; i++)
                {
                    Console.Write(submatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSum);
        }
    }
}
