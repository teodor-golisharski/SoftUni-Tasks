namespace CollectingStarsGame
{
    internal class Program
    {
        static int starsGathered = 2;
        static int currentRow = 0;
        static int currentColumn = 0;

        static void Move(char[,] matrix, string command, int posRow, int posCol)
        {
            bool flag = ValidateCommand(command, matrix.GetLength(0), posRow, posCol);

            if (!flag)
            {
                command = "teleport";
            }

            switch (command)
            {
                case "left": MoveToPosition(matrix, posRow, posCol, posRow, --posCol); break;
                case "right": MoveToPosition(matrix, posRow, posCol, posRow, ++posCol); break;
                case "up": MoveToPosition(matrix, posRow, posCol, --posRow, posCol); break;
                case "down": MoveToPosition(matrix, posRow, posCol, ++posRow, posCol); break;
                case "teleport": MoveToPosition(matrix, posRow, posCol, 0, 0); break;

                default:
                    break;
            }
        }

        static void MoveToPosition(char[,] matrix, int posRow, int posCol, int toRow, int toCol)
        {
            switch (matrix[toRow, toCol])
            {
                case '*':
                    starsGathered++;
                    matrix[toRow, toCol] = 'P';
                    currentRow = toRow;
                    currentColumn = toCol;

                    matrix[posRow, posCol] = '.';
                    break;
                case '.':
                    matrix[posRow, posCol] = '.';

                    matrix[toRow, toCol] = 'P';
                    currentRow = toRow;
                    currentColumn = toCol;
                    break;
                case '#':
                    starsGathered--;
                    break;
                default:
                    break;
            }
        }

        static bool ValidateCommand(string command, int n, int posRow, int posCol)
        {
            switch (command)
            {
                case "left": posCol--; break;
                case "right": posCol++; break;
                case "up": posRow--; break;
                case "down": posRow++; break;
                default: break;
            }
            return posRow >= 0 && posRow < n && posCol >= 0 && posCol < n;
        }

        static void FindP(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'P')
                    {
                        currentRow = i;
                        currentColumn = j;
                    }
                }
            }
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()!);

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] array = Console.ReadLine()!
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = array[col];
                }
            }
            FindP(matrix);

            string command = Console.ReadLine()!;

            while (true)
            {
                Move(matrix, command, currentRow, currentColumn);

                if (starsGathered <= 0)
                {
                    Console.WriteLine("Game over! You are out of any stars.");
                    break;
                }
                if (starsGathered >= 10)
                {
                    Console.WriteLine("You won! You have collected 10 stars.");
                    break;
                }
                command = Console.ReadLine()!;
            }
            Console.WriteLine($"Your final position is [{currentRow}, {currentColumn}]");
            PrintMatrix(matrix);
        }
    }
}
