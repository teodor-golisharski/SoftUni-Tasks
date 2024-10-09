using System;
using System.Collections.Generic;
using System.Linq;

namespace TilesMaster
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> locations = new Dictionary<string, int>();
            locations.Add("Countertop", 0);
            locations.Add("Floor", 0);
            locations.Add("Oven", 0);
            locations.Add("Sink", 0);
            locations.Add("Wall", 0);

            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> greyTiles = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            while (true)
            {
                if (greyTiles.Count == 0)
                {
                    break;
                }
                else if (whiteTiles.Count == 0)
                {
                    break;
                }
                int currentGrey = greyTiles.Peek();
                int currentWhite = whiteTiles.Peek();
                if (currentGrey == currentWhite)
                {
                    int sum = currentWhite + currentGrey;
                    switch (sum)
                    {
                        case 40:
                            locations["Sink"]++;
                            break;

                        case 50:
                            locations["Oven"]++;
                            break;

                        case 60:
                            locations["Countertop"]++;
                            break;

                        case 70:
                            locations["Wall"]++;
                            break;

                        default:
                            locations["Floor"]++;
                            break;
                    }
                    greyTiles.Dequeue();
                    whiteTiles.Pop();
                }
                else
                {
                    int tempWhite = whiteTiles.Pop() / 2;
                    whiteTiles.Push(tempWhite);
                    int tempGrey = greyTiles.Dequeue();
                    greyTiles.Enqueue(tempGrey);
                }
            }
            if (whiteTiles.Count == 0)
            {
                Console.WriteLine($"White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }
            if (greyTiles.Count == 0)
            {
                Console.WriteLine($"Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }
            foreach (var item in locations.Where(x => x.Value > 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
