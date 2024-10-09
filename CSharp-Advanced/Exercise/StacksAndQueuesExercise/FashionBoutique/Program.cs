using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            int capacity = int.Parse(Console.ReadLine());
            int currentRack = capacity;
            int racksNeeded = 1;
            while (stack.Count > 0)
            {
                int current = stack.Peek();
                if (current <= currentRack)
                {
                    currentRack -= current;
                    stack.Pop();
                }
                else
                {
                    currentRack = capacity;
                    racksNeeded++;
                }
            }
            Console.WriteLine(racksNeeded);
        }
    }
}
