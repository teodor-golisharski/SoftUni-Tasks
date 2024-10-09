using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>(Console.ReadLine().Split(", ").ToList());
            string commands = Console.ReadLine();
            while (queue.Count > 0)
            {
                switch (commands)
                {
                    case "Play":
                        if (queue.Count == 0)
                        {
                            Console.WriteLine("No more songs!");
                            return;
                        }
                        else
                        {
                            queue.Dequeue();
                        }
                        break;

                    case "Show":
                        Console.WriteLine(string.Join(", ", queue));
                        break;
                }
                if (commands.StartsWith("Add"))
                {
                    string song = commands.Substring(4);
                    if(queue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }    
                    else
                    {
                        queue.Enqueue(song);
                    }
                }
                commands = Console.ReadLine();
            }
            Console.WriteLine("No more songs!");
        }
    }
}
