using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string array = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '(' || array[i] == '[' || array[i] == '{')
                {
                    stack.Push(array[i]);
                }
                else if(stack.Count > 0)
                {
                    char current = array[i];
                    char currStack = stack.Peek();
                    switch (current)
                    {
                        case ')':
                            if (currStack == '(')
                            {
                                stack.Pop();
                            }
                            break;

                        case ']':
                            if (currStack == '[')
                            {
                                stack.Pop();
                            }
                            break;

                        case '}':
                            if (currStack == '{')
                            {
                                stack.Pop();
                            }
                            break;
                    }
                }
                else if(stack.Count == 0)
                {
                    Console.WriteLine("NO");return;
                }
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
