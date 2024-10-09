using System;
using System.Linq;

namespace MatrixShuffling
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
            string[] command = Console.ReadLine().Split();
            while (command[0] != "END")
            {
                string commandName = command[0];
                if (commandName == "swap" && command.Length == 5)
                {
                    int row1 = int.Parse(command[1]);
                    int col1 = int.Parse(command[2]);
                    int row2 = int.Parse(command[3]);
                    int col2 = int.Parse(command[4]);
                    if (CordinatesValidation(row1, col1, row2, col2, rows, cols))
                    {
                        int temp = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp;
                        Print(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine().Split();
            }
        }
        static bool CordinatesValidation(int row1, int col1, int row2, int col2, int rows, int cols)
        {
            if (row1 >= 0 && row1 <= rows)
            {
                if (col1 >= 0 && col1 <= cols)
                {
                    if (row2 >= 0 && row2 <= rows)
                    {
                        if (col2 >= 0 && col2 <= cols)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        static void Print(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

