using System;

namespace WallDestroyer
{
    public class Program
    {
        private static int vankoRow;
        private static int vankoCol;
        private static char[,] matrix;

        private static int holesCount = 1;
        private static int rodsHit;

        private static bool isAlive = true;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;
                        break;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                if (command == "up")
                {
                    Move(-1, 0);
                }
                else if (command == "down")
                {
                    Move(1, 0);
                }
                else if (command == "left")
                {
                    Move(0, -1);
                }
                else if (command == "right")
                {
                    Move(0, 1);
                }
                if (!isAlive)
                {
                    break;
                }
                command = Console.ReadLine();
            }
            if (isAlive)
            {
                Console.WriteLine($"Vanko managed to make {holesCount} hole(s) and he hit only {rodsHit} rod(s).");
            }
            Print(n);
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        static void Move(int row, int col)
        {
            if (IsInside(vankoRow + row, vankoCol + col))
            {
                if (matrix[vankoRow + row, vankoCol + col] == 'R')
                {
                    rodsHit++;
                    Console.WriteLine("Vanko hit a rod!");
                }
                else if (matrix[vankoRow + row, vankoCol + col] == 'C')
                {
                    matrix[vankoRow, vankoCol] = '*';
                    vankoRow += row;
                    vankoCol += col;
                    holesCount++;
                    matrix[vankoRow, vankoCol] = 'E';
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCount} hole(s).");
                    isAlive = false;
                }
                else if (matrix[vankoRow + row, vankoCol + col] == '-')
                {
                    matrix[vankoRow, vankoCol] = '*';
                    vankoRow += row;
                    vankoCol += col;
                    matrix[vankoRow, vankoCol] = 'V';
                    holesCount++;
                }
                else if (matrix[vankoRow + row, vankoCol + col] == '*')
                {
                    matrix[vankoRow, vankoCol] = '*';
                    Console.WriteLine($"The wall is already destroyed at position [{vankoRow + row}, {vankoCol + col}]!");
                    vankoRow += row;
                    vankoCol += col;
                    matrix[vankoRow, vankoCol] = 'V';
                }
            }
        }

        static void Print(int n)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
