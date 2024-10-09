using System;
using System.Collections.Generic;
using System.Linq;

namespace HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> players = new Queue<string>(Console.ReadLine().Split().ToList());
            int n = int.Parse(Console.ReadLine());
            int toss = n;
            while (players.Count > 1)
            {
                if (toss > 1)
                {
                    string saved = players.Dequeue();
                    players.Enqueue(saved);
                    toss--;
                }
                else
                {
                    string removed = players.Dequeue();
                    Console.WriteLine($"Removed {removed}");
                    toss = n;
                }
            }
            Console.WriteLine($"Last is {players.Dequeue()}");
        }
    }
}
