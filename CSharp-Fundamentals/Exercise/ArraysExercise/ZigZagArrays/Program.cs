using System;

namespace ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr1 = new int[n];
            int[] arr2 = new int[n];
            for (int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Split();
                int a, b;
                if (i % 2 != 0)
                {
                    a = int.Parse(input[0]);
                    b = int.Parse(input[1]);
                }
                else
                {
                    b = int.Parse(input[0]);
                    a = int.Parse(input[1]);
                }
                arr1[i - 1] = a;
                arr2[i - 1] = b;
            }
            foreach (var items1 in arr1)
            {
                Console.Write(items1 + " ");
            }
            Console.WriteLine();
            foreach (var items2 in arr2)
            {
                Console.Write(items2 + " ");
            }
        }
    }
}
