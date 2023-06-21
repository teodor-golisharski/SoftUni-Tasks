using System;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                arr[i] = num;
                sum += arr[i];
            }
            foreach (var items in arr)
            {
                Console.Write(items + " ");
            }
            Console.WriteLine("\n"+sum);
        }
    }
}
