using System;
using System.Linq;

namespace ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] input = Console.ReadLine().Split();
            while(input[0] != "end")
            {
                switch(input[0])
                {
                    case "swap":
                        Swap(arr, int.Parse(input[1]), int.Parse(input[2]));
                        break;

                    case "multiply":
                        Multiply(arr, int.Parse(input[1]), int.Parse(input[2]));
                        break;

                    case "decrease":
                        Decrease(arr);
                        break;
                }
                input = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(", ", arr));
        }
        static int[] Swap (int[]arr, int index1, int index2)
        {
            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
            return arr;
        }
        static int[] Multiply(int[] arr, int index1, int index2)
        {
            arr[index1] *= arr[index2];
            return arr;
        }
        static int[] Decrease (int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i]--;
            }
            return arr;
        }
    }
}
