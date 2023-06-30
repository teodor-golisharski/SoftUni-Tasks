using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split().ToList();
            string[] input = Console.ReadLine().Split();
            int counter = 0;
            while (input[0] != "end")
            {
                counter++;
                int index1 = int.Parse(input[0]);
                int index2 = int.Parse(input[1]);
                if (index1 > elements.Count - 1 || index1 < 0 || index2 > elements.Count - 1 || index2 < 0 || index2 == index1)
                {
                    Cheat(elements, counter);
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                else if (elements[index1] == elements[index2])
                {
                    string temp = elements[index1];
                    if (index1 > index2)
                    {
                        elements.RemoveAt(index1);
                        elements.RemoveAt(index2);
                    }
                    else
                    {
                        elements.RemoveAt(index2);
                        elements.RemoveAt(index1);
                    }
                    Console.WriteLine($"Congrats! You have found matching elements - {temp}!");
                }
                else if (elements[index1] != elements[index2])
                {
                    Console.WriteLine("Try again!");
                }
                if (elements.Count == 0)
                {
                    Console.WriteLine($"You have won in {counter} turns!");
                    return;
                }
                input = Console.ReadLine().Split();
            }
            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(" ", elements));
        }
        static List<string> Cheat(List<string> elements, int counter)
        {
            elements.Insert(elements.Count / 2, $"-{counter}a");
            elements.Insert(elements.Count / 2, $"-{counter}a");
            return elements;
        }
    }
}
