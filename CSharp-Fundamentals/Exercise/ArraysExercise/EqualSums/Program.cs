using System;
using System.Linq;

namespace EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int leftSum = 0;
            int rightSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr.Length == 1)
                {
                    Console.WriteLine(0); return;
                }
                leftSum = 0;
                for (int left = i; left > 0; left--)
                {
                    int nextpos = left - 1;
                    if (left > 0)
                    {
                        leftSum += arr[nextpos];
                    }
                }
                rightSum = 0;
                for (int right = i; right < arr.Length; right++)
                {
                    int nextEl = right + 1;
                    if (right < arr.Length - 1)
                    {
                        rightSum += arr[nextEl];
                    }
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i); return;
                }
            }
            Console.WriteLine("no");
        }
    }
}
