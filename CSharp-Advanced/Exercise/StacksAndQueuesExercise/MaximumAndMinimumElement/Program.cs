using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int query = arr[0];
                switch (query)
                {
                    case 1:
                        stack.Push(arr[1]);
                        break;

                    case 2:
                        stack.Pop();
                        break;

                    case 3:
                        if (stack.Count > 0)
                        {
                            int max = int.MinValue;
                            List<int> list = new List<int>();
                            list = stack.ToList();
                            for (int j = 0; j < list.Count; j++)
                            {
                                if (list[j] > max)
                                {
                                    max = list[j];
                                }
                            }
                            Console.WriteLine(max);
                        }
                        break;

                    case 4:
                        if (stack.Count > 0)
                        {
                            int min = int.MaxValue;
                            List<int> list1 = new List<int>();
                            list1 = stack.ToList();
                            for (int j = 0; j < stack.Count; j++)
                            {
                                if (list1[j] < min)
                                {
                                    min = list1[j];
                                }
                            }
                            Console.WriteLine(min);
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
