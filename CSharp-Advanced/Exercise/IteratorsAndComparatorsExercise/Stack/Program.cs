using System;
using System.Linq;

namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> customStack = new Stack<string>();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command
                            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
                string action = tokens[0];
                switch (action)
                {
                    case "Push":
                        string[] itemsToPush = tokens.Skip(1).ToArray();
                        foreach (var item in itemsToPush)
                        {
                            customStack.Push(item);
                        }
                        break;

                    case "Pop":
                        try
                        {
                            customStack.Pop();
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        break;
                }
            }
            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
