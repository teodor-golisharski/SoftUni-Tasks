using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());

            string[] command = Console.ReadLine().Split();
            while (command[0].ToLower() != "end")
            {
                string mainCommand = command[0].ToLower();
                switch (mainCommand)
                {
                    case "add":
                        int a = int.Parse(command[1]);
                        stack.Push(a);
                        int b = int.Parse(command[2]);
                        stack.Push(b);
                        break;

                    case "remove":
                        int c = int.Parse(command[1]);
                        if (c <= stack.Count)
                        {
                            for (int i = 0; i < c; i++)
                            {
                                stack.Pop();
                            }
                        }
                        break;
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine("Sum: " + stack.Sum());
        }
    }
}
