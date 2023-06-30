using System;
using System.Collections.Generic;
using System.Linq;

namespace MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] input = Console.ReadLine().Split();
            while (input[0] != "End")
            {
                int index = int.Parse(input[1]);
                switch (input[0])
                {
                    case "Shoot":
                        if (index < 0 || index > targets.Count - 1)
                        {
                            break;
                        }
                        targets[index] -= int.Parse(input[2]);
                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                        break;

                    case "Add":
                        if(index < 0 || index > targets.Count-1)
                        {
                            Console.WriteLine("Invalid placement!");
                        }
                        else
                        {
                            targets.Insert(index, int.Parse(input[2]));
                        }
                        break;

                    case "Strike":
                        int radius = int.Parse(input[2]);
                        if (index - radius < 0 || index + radius > targets.Count - 1)
                        {
                            Console.WriteLine("Strike missed!");
                        }
                        else
                        {
                            targets.RemoveRange(index - radius, radius * 2 + 1);
                        }
                        break;
                }
                input = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join("|", targets));
        }
    }
}
