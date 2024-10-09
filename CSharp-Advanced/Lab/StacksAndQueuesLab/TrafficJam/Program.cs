using System;
using System.Collections.Generic;

namespace TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int sum = 0;
            Queue<string> queue = new Queue<string>();
            while (input != "end")
            {
                if (input != "green")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    if (queue.Count >= n)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            string carPassed = queue.Dequeue();
                            Console.WriteLine($"{carPassed} passed!");
                            sum++;
                        }
                    }
                    else
                    {
                        int count = queue.Count;
                        for (int i = 0; i < count; i++)
                        {
                            string carPassed = queue.Dequeue();
                            Console.WriteLine($"{carPassed} passed!");
                            sum++;
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{sum} cars passed the crossroads.");
        }
    }
}
