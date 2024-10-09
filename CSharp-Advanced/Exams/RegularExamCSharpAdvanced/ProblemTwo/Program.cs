using System;
using System.Linq;
using System.Security.Cryptography;

namespace ProblemTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string racingNumber = Console.ReadLine();

            int distanceDriven = 0;

            char[,] matrix = new char[n, n];

            int raceCarRow = 0;
            int raceCarCol = 0;

            for (int row = 0; row < n; row++)
            {
                char[] array = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = array[col];
                }
            }

            string command = Console.ReadLine();
            while (true)
            {
                if (command == "End")
                {
                    break;
                }
                switch (command)
                {
                    case "down":
                        raceCarRow++;
                        break;

                    case "up":
                        raceCarRow--;
                        break;

                    case "right":
                        raceCarCol++;
                        break;

                    case "left":
                        raceCarCol--;
                        break;
                }
                if (matrix[raceCarRow, raceCarCol] == '.')
                {
                    distanceDriven += 10;
                }
                else if (matrix[raceCarRow, raceCarCol] == 'T')
                {
                    matrix[raceCarRow, raceCarCol] = '.';
                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            if (matrix[row, col] == 'T')
                            {
                                raceCarRow = row;
                                raceCarCol = col;
                                distanceDriven += 30;
                                matrix[raceCarRow, raceCarCol] = '.';
                            }
                        }
                    }
                }
                else if(matrix[raceCarRow, raceCarCol] == 'F')
                {
                    distanceDriven += 10;
                    Console.WriteLine($"Racing car {racingNumber} finished the stage!");
                    Console.WriteLine($"Distance covered {distanceDriven} km.");
                    matrix[raceCarRow, raceCarCol] = 'C';
                    Print(matrix);
                    return;
                }
                command = Console.ReadLine();
            }
            matrix[raceCarRow, raceCarCol] = 'C';
            Console.WriteLine($"Racing car {racingNumber} DNF.");
            Console.WriteLine($"Distance covered {distanceDriven} km.");
            Print(matrix);
        }
        static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
