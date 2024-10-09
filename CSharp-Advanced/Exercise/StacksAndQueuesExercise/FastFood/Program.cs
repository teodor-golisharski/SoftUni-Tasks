using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int resource = int.Parse(Console.ReadLine());
            Queue<int> q = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            int max = q.Max();
            int count = q.Count;
            for (int i = 0; i < count; i++)
            {
                int current = q.Peek();
                if(resource >= current)
                {
                    resource-=current;
                    q.Dequeue();
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(max);
            if(q.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", q)}");
            }
        }
    }
}
