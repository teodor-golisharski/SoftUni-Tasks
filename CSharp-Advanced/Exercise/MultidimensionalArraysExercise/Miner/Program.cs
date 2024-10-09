using System;
using System.Collections.Generic;
using System.Linq;

namespace Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            Queue<string> commands = new Queue<string>(Console.ReadLine().Split().ToList());
            int currentRow = 0;
            int currentCol = 0;
            int coalsAvailable = 0;
            for (int row = 0; row < size; row++)
            {
                char[] chars = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = chars[col];
                    if (matrix[row, col] == 's')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                    else if (matrix[row, col] == 'c')
                    {
                        coalsAvailable++;
                    }
                }
            }
            int collectedCoals = 0;
            for (int i = 0; i < commands.Count; i++)
            {
                string command = commands.Dequeue();
                bool flag = false;
                switch (command)
                {
                    case "left":
                        if (CellValidation(currentRow, currentCol - 1, matrix))
                        {
                            currentCol--;
                            flag = true;
                        }
                        break;

                    case "right":
                        if (CellValidation(currentRow, currentCol + 1, matrix))
                        {
                            currentCol++;
                            flag = true;
                        }
                        break;

                    case "up":
                        if (CellValidation(currentRow - 1, currentCol, matrix))
                        {
                            currentRow--;
                            flag = true;
                        }
                        break;

                    case "down":
                        if (CellValidation(currentRow + 1, currentCol, matrix))
                        {
                            currentRow++;
                            flag = true;
                        }
                        break;
                }
                if (flag)
                {
                    char c = matrix[currentRow, currentCol];
                    switch (c)
                    {
                        case 'e':
                            Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                            return;
                            

                        case 'c':
                            collectedCoals++;
                            matrix[currentRow, currentCol] = '*';
                            if (collectedCoals == coalsAvailable)
                            {
                                Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                                return;
                            }
                            break;
                    }
                }
                commands.Enqueue(command);
            }
            Console.WriteLine($"{coalsAvailable - collectedCoals} coals left. ({currentRow}, {currentCol})");
        }

        static bool CellValidation(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
