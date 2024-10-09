using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] matrix = new double[rows][];
            for (int row = 0; row < rows; row++)
            {
                double[] cols = Console.ReadLine().Split().Select(double.Parse).ToArray();
                matrix[row] = cols;
            }
            for (int row = 0; row < rows - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int i = 0; i < matrix[row].Length; i++)
                    {
                        matrix[row][i] *= 2;
                    }
                    for (int i = 0; i < matrix[row + 1].Length; i++)
                    {
                        matrix[row + 1][i] *= 2;
                    }
                }
                else
                {
                    for (int i = 0; i < matrix[row].Length; i++)
                    {
                        matrix[row][i] /= 2;
                    }
                    for (int i = 0; i < matrix[row + 1].Length; i++)
                    {
                        matrix[row + 1][i] /= 2;
                    }
                }
            }
            string[] commands = Console.ReadLine().Split();
            while (commands[0] != "End")
            {
                string mainCommand = commands[0];
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);
                if (IndexValidation(row, col, rows, matrix))
                {
                    switch (mainCommand.ToLower())
                    {
                        case "add":
                            matrix[row][col] += value;
                            break;

                        case "subtract":
                            matrix[row][col] -= value;
                            break;
                    }
                }
                commands = Console.ReadLine().Split();
            }
            Print(matrix);
        }
        static bool IndexValidation(int row, int col, int rows, double[][] matrix)
        {
            if (row >= 0 && row < rows)
            {
                if (col >= 0 && col < matrix[row].Length)
                {
                    return true;
                }
            }
            return false;
        }
        static void Print(double[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int cols = matrix[row].Length;
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

