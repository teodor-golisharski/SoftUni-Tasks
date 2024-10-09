using System;
using System.Diagnostics;

namespace PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = new char[8, 8];

            //fill matrix
            for (int row = 0; row < 8; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < 8; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            //black and white coordinates
            int blackRow = 0;
            int blackCol = 0;
            int whiteRow = 0;
            int whiteCol = 0;

            //find coordinates
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (matrix[row, col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                        continue;
                    }
                    else if (matrix[row, col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                        continue;
                    }
                }
            }

            while (true)
            {
                if (IsInMatrix(matrix, whiteRow - 1, whiteCol - 1) && matrix[whiteRow - 1, whiteCol - 1] == 'b')
                {
                    Captured("White", whiteRow - 1, whiteCol - 1);
                    return;
                }
                else if (IsInMatrix(matrix, whiteRow - 1, whiteCol + 1) && matrix[whiteRow - 1, whiteCol + 1] == 'b')
                {
                    Captured("White", whiteRow - 1, whiteCol + 1);
                    return;
                }
                else
                {
                    matrix[whiteRow, whiteCol] = '-';
                    whiteRow--;
                    matrix[whiteRow, whiteCol] = 'w';
                    if (whiteRow == 0)
                    {
                        Promoted("White", whiteRow, whiteCol);
                        return;
                    }
                }

                if (IsInMatrix(matrix, blackRow + 1, blackCol - 1) && matrix[blackRow + 1, blackCol - 1] == 'w')
                {
                        Captured("Black", blackRow + 1, blackCol - 1);
                        return;                   
                }
                else if (IsInMatrix(matrix, blackRow + 1, blackCol + 1) && matrix[blackRow + 1, blackCol + 1] == 'w')
                {
                        Captured("Black", blackRow + 1, blackCol + 1);
                        return;
                }
                else
                {

                    matrix[blackRow, blackCol] = '-';
                    blackRow++;
                    matrix[blackRow, blackCol] = 'b';
                    if (blackRow == 7)
                    {
                        Promoted("Black", blackRow, blackCol);
                        return;
                    }
                }
            }
        }
        static bool IsInMatrix(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        static string Coordinates(int row, int col)
        {
            string coordinate = "";
            switch (col)
            {
                case 0: coordinate += "a"; break;
                case 1: coordinate += "b"; break;
                case 2: coordinate += "c"; break;
                case 3: coordinate += "d"; break;
                case 4: coordinate += "e"; break;
                case 5: coordinate += "f"; break;
                case 6: coordinate += "g"; break;
                case 7: coordinate += "h"; break;
            }
            coordinate += (8 - row);
            return coordinate;
        }
        static void Promoted(string type, int row, int col)
        {
            Console.WriteLine($"Game over! {type} pawn is promoted to a queen at {Coordinates(row, col)}.");
        }
        static void Captured(string type, int row, int col)
        {
            Console.WriteLine($"Game over! {type} capture on {Coordinates(row, col)}.");
        }
    }
}
