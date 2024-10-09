using System;
using System.Data.Common;
using System.Linq;

namespace JaggedArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jagged = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jagged[row] = arr;
            }
            string[] command = Console.ReadLine().Split();
            while (command[0] != "END")
            {
                int rowValue = int.Parse(command[1]);
                int colValue = int.Parse(command[2]);
                int value = int.Parse(command[3]);
                bool flag = rowValue >= rows || rowValue < 0 || colValue >= jagged[rowValue].Length || colValue < 0;
                switch (command[0])
                {
                    case "Add":
                        if (flag)
                        {
                            Console.WriteLine("Invalid coordinates");
                        }
                        else
                        {
                            jagged[rowValue][colValue] += value;
                        }
                        break;

                    case "Subtract":
                        if (flag)
                        {
                            Console.WriteLine("Invalid coordinates");
                        }
                        else
                        {
                            jagged[rowValue][colValue] -= value;
                        }
                        break;
                }
                command = Console.ReadLine().Split();
            }
            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write($"{jagged[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
