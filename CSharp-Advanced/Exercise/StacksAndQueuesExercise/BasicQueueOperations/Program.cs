using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = arr[0];
            int s = arr[1];
            int x = arr[2];

            Queue<int> q = new Queue<int>();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < n; i++)
            {
                q.Enqueue(numbers[i]);
            }
            if (s <= q.Count)
            {
                for (int i = 0; i < s; i++)
                {
                    q.Dequeue();
                }
            }
            else
            {
                int count = q.Count;
                for (int i = 0; i < count; i++)
                {
                    q.Dequeue();
                }
            }
            if(q.Contains(x))
            {
                Console.WriteLine("true");
                return;
            }
            else if(q.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            else
            {
                int min = int.MaxValue;
                while (q.Count > 0)
                {
                    int last = q.Dequeue();
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
