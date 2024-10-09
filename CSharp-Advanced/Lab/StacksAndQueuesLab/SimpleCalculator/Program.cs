using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList());
            int sum = 0;
            while(stack.Count > 1)
            {
                string num = stack.Pop();
                string symbol = stack.Pop();
                if(symbol == "+")
                {
                    sum += int.Parse(num);
                }
                else if(symbol == "-")
                {
                    sum -= int.Parse(num);
                }
            }
            sum += int.Parse(stack.Pop());
            Console.WriteLine(sum);
        }
    }
}
