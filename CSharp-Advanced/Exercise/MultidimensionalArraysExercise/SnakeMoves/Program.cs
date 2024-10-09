using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = dimensions[0];
            int m = dimensions[1];
            string input = Console.ReadLine();
            Queue<char> snake = new Queue<char>(input.ToCharArray());
            char[,] matrix = new char[n, m];
            for (int row = 0; row < n; row++)
            {
                if ((row + 1) % 2 == 0)
                {
                    for (int col = m - 1; col >= 0; col--)
                    {
                        char current = snake.Dequeue();
                        matrix[row, col] = current;
                        snake.Enqueue(current);
                    }
                }
                else
                {
                    for (int col = 0; col < m; col++)
                    {
                        char current = snake.Dequeue();
                        matrix[row, col] = current;
                        snake.Enqueue(current);
                    }
                }
            }
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
