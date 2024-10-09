using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToList();

            ListyIterator<string> iterator = new ListyIterator<string>(items);
            
            string command = Console.ReadLine();
            
            while (command != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;

                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;

                    case "Print":
                        try
                        {
                            iterator.Print();
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        break;
                    case "PrintAll":
                        try
                        {
                            iterator.PrintAll();
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
