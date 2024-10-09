using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string text = string.Empty;
            Stack<string> stack = new Stack<string>();
            stack.Push(text);
            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();
                string token = commands[0];
                switch (token)
                {
                    case "1":
                        stack.Push(text);
                        string someString = commands[1];
                        text += someString;
                        break;

                    case "2":
                        stack.Push(text);
                        int count = int.Parse(commands[1]);
                        text = text.Substring(0, text.Length - count);
                        break;

                    case "3":
                        int position = int.Parse(commands[1]);
                        char element = text[position - 1];
                        Console.WriteLine(element);
                        break;

                    case "4":
                        text = stack.Pop();
                        break;
                }
            }
        }
    }
}
