using System;

namespace KnightGame
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n < 3)
            {
                Console.WriteLine(0);
                return;
            }
            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            int deleteCount = 0;
            while (true)
            {
                int countAttacks = 0;
                int attackerRow = 0;
                int attackerCol = 0;
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int attacked = CountAttackedKnights(row, col, n, matrix);
                            if (countAttacks < attacked)
                            {
                                countAttacks = attacked;
                                attackerRow = row;
                                attackerCol = col;
                            }
                        }
                    }
                }
                if (countAttacks == 0)
                {
                    break;
                }
                else
                {
                    matrix[attackerRow, attackerCol] = '0';
                    deleteCount++;
                }
            }
            Console.WriteLine(deleteCount);
        }
        static int CountAttackedKnights(int row, int col, int n, char[,] matrix)
        {
            int attacked = 0;

            if (CellValidation(row - 1, col - 2, n))
            {
                if (matrix[row - 1, col - 2] == 'K')
                {
                    attacked++;
                }
            }
            if (CellValidation(row - 2, col - 1, n))
            {
                if (matrix[row - 2, col - 1] == 'K')
                {
                    attacked++;
                }
            }
            if (CellValidation(row - 2, col + 1, n))
            {
                if (matrix[row - 2, col + 1] == 'K')
                {
                    attacked++;
                }
            }
            if (CellValidation(row - 1, col + 2, n))
            {
                if (matrix[row - 1, col + 2] == 'K')
                {
                    attacked++;
                }
            }
            if (CellValidation(row + 1, col + 2, n))
            {
                if (matrix[row + 1, col + 2] == 'K')
                {
                    attacked++;
                }
            }
            if (CellValidation(row + 2, col + 1, n))
            {
                if (matrix[row + 2, col + 1] == 'K')
                {
                    attacked++;
                }
            }
            if (CellValidation(row + 2, col - 1, n))
            {
                if (matrix[row + 2, col - 1] == 'K')
                {
                    attacked++;
                }
            }
            if (CellValidation(row + 1, col - 2, n))
            {
                if (matrix[row + 1, col - 2] == 'K')
                {
                    attacked++;
                }
            }
            return attacked;
        }
        static bool CellValidation(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }
    }
}
