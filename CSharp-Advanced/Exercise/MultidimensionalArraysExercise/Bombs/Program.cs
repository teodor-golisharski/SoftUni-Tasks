using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                string[] array = Console.ReadLine().Split();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = int.Parse(array[col]);
                }
            }
            //CheckUp - Passed

            string[] input = Console.ReadLine().Split();
            Queue<Bomb> bombsQueue = new Queue<Bomb>();
            foreach (var item in input)
            {
                int row = int.Parse(item.Split(',')[0]);
                int col = int.Parse(item.Split(',')[1]);
                Bomb bomb = new Bomb(row, col);
                bombsQueue.Enqueue(bomb);
            }

            for (int i = 0; i < bombsQueue.Count; i++)
            {
                Bomb bomb = bombsQueue.Peek();
                int row = bomb.Row;
                int col = bomb.Col;
                int bombPower = matrix[row, col];
                if (bombPower > 0)
                {

                    //Row: 0
                    for (int x = 1; x >= -1; x--)
                    {
                        for (int y = 1; y >= -1; y--)
                        {
                            if (CellValidation(row - x, col - y, matrix))
                            {
                                if (x != 0 || y != 0)
                                {
                                    if (matrix[row - x, col - y] > 0 && matrix[row, col] > 0)
                                    {
                                        matrix[row - x, col - y] -= bombPower;
                                    }
                                }
                            }
                        }
                    }
                    matrix[row, col] = 0;
                }
                bombsQueue.Dequeue();
                bombsQueue.Enqueue(bomb);
            }
            int activeCells = 0;
            int sum = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        activeCells++;
                        sum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {activeCells}");
            Console.WriteLine($"Sum: {sum}");
            Print(matrix);
        }
        static bool CellValidation(int row, int col, int[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
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
    class Bomb
    {
        public Bomb(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
    }
}
