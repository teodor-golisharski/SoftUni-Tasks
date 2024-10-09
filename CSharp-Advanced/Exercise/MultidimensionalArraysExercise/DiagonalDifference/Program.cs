using System;
using System.Linq;

namespace DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] array = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                int[] sub = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < sub.Length; col++)
                {
                    array[row, col] = sub[col];
                }
            }
            int primaryDiagonal = 0;
            for (int i = 0; i < n; i++)
            {
                primaryDiagonal += array[i, i];
            }
            int secondaryDiagonal = 0;
            int indexCol = n - 1;
            int indexRow = 0;
            while (indexCol >= 0)
            {
                secondaryDiagonal += array[indexRow, indexCol];
                indexRow++;
                indexCol--;
            }
            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}
