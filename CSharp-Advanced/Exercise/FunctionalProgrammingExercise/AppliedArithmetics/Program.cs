using System;
using System.Linq;

namespace AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<int[]> add = nums =>
            {
                for(int i = 0; i < nums.Length; i++)
                {
                    nums[i]++;
                }
            };

            Action<int[]> multiply = nums =>
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i]*=2;
                }
            };

            Action<int[]> subtract = nums =>
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i]--;
                }
            };

            Action<int[]> print = x => Console.WriteLine(string.Join(" ", x));

            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "add": add(nums); break;

                    case "multiply": multiply(nums); break;

                    case "subtract": subtract(nums); break;

                    case "print": print(nums); break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
