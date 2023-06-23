using System;
using System.Linq;
using System.Collections.Generic;

namespace ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] input = Console.ReadLine().Split();
            while (input[0] != "end")
            {
                if (input[0] == "exchange")
                {
                    int n = int.Parse(input[1]);
                    arr = Exchange(arr, n);
                }
                else if (input[0] == "max" || input[0] == "min")
                {
                    MinMax(arr, input[0], input[1]);
                }
                else
                {
                    firstLast(arr, input[0], int.Parse(input[1]), input[2]);
                }
                input = Console.ReadLine().Split();
            }
            Console.WriteLine($"[{string.Join(", ", arr)}]");
        }
        static int[] Exchange(int[] arr, int n)
        {
            if (n >= arr.Length || n < 0)
            {
                Console.WriteLine("Invalid index");
                return arr;
            }
            int[] result = new int[arr.Length];
            int index = 0;
            for (int i = n + 1; i < arr.Length; i++)
            {
                result[index] = arr[i];
                index++;
            }
            for (int i = 0; i <= n; i++)
            {
                result[index] = arr[i];
                index++;
            }
            return result;
        }
        static void MinMax(int[] arr, string minMax, string evenOdd)
        {
            int index = -1;
            int max = int.MinValue;
            int min = int.MaxValue;
            int resultEvenOdd = 1;

            if (evenOdd == "even") resultEvenOdd = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == resultEvenOdd)
                {
                    if (minMax == "min" && min >= arr[i])
                    {
                        min = arr[i];
                        index = i;
                    }
                    else if (minMax == "max" && max <= arr[i])
                    {
                        max = arr[i];
                        index = i;
                    }
                }
            }
            Console.WriteLine(index > -1 ? index.ToString() : "No matches");
        }
        static void firstLast(int[] arr, string pos, int count, string evenOdd)
        {
            if (count > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            if (count == 0)
            {
                Console.WriteLine("[]");
                return;
            }
            int resultEvenOdd = 1;

            if (evenOdd == "even") resultEvenOdd = 0;
            int count1 = 0;
            List<int> nums = new List<int>();

            if (pos == "first")
            {
                foreach (int element in arr)
                {
                    if (element % 2 == resultEvenOdd)
                    {
                        count1++;
                        nums.Add(element);
                    }
                    if (count1 == count) break;
                }
            }
            else
            {
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (arr[i] % 2 == resultEvenOdd)
                    {
                        count1++;
                        nums.Add(arr[i]);
                    }
                    if (count1 == count) break;
                }
                nums.Reverse();
            }
            Console.WriteLine($"[{string.Join(", ", nums)}]");
        }
    }
}
