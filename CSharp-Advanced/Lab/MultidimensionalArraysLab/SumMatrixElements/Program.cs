using System;

namespace SumMatrixElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] s = Console.ReadLine().Split(", ");
            int rows = int.Parse(s[0]);
            int cols = int.Parse(s[1]);
            int[,] array = new int[rows, cols];
            int sum = 0;
            for (int row = 0; row < rows; row++)
            {
                string[] current = Console.ReadLine().Split(", ");
                for (int col = 0; col < cols; col++)
                {
                    array[row, col] = int.Parse(current[col]);
                    sum+=array[row, col];
                }
            }
            Console.WriteLine(array.GetLength(0));
            Console.WriteLine(array.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
