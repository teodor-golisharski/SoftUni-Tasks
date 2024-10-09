using System;
using System.Linq;

namespace PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] array = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    array[row, col] = arr[col];
                }
            }
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += array[i,i];
            }
            Console.WriteLine(sum);
        }
    }
}
