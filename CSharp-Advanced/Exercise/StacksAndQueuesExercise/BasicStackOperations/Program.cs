using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = arr[0];
            int s = arr[1];
            int x = arr[2];
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(x))
            {
                Console.WriteLine("true");
                return;
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            else
            {
                int min = int.MaxValue;
                while (stack.Count > 0)
                {
                    int last = stack.Pop();
                    if (last < min)
                    {
                        min = last;
                    }
                }
                Console.WriteLine(min);
                return;
            }
        }
    }
}
