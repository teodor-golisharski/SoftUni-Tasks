using System;
using System.Linq;

namespace MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int counter = 0;
            int max = 0;
            int startPos = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    counter++;
                    if (counter > max)
                    {
                        startPos = i - counter;
                        max = counter;
                    }
                }
                else
                {
                    counter = 0;
                }
            }
            for (int j = startPos + 1; j <= startPos + max + 1; j++)
            {
                Console.Write(arr[j] + " ");
            }
        }
    }
}
