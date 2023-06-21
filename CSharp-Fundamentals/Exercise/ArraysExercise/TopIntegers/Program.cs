using System;
using System.Linq;

namespace TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool flag = false;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false; break;
                    }
                }
                if (flag == true)
                {
                    Console.Write(arr[i] + " ");
                }
            }
            Console.Write(arr[arr.Length - 1]);
        }
    }
}
