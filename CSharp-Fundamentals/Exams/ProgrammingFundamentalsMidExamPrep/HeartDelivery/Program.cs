using System;
using System.Collections.Generic;
using System.Linq;

namespace HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> neighborhood = Console.ReadLine().Split('@').Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split();
            int index = 0;
            while (command[0] != "Love!")
            {
                if (command[0] == "Jump")
                {
                    int length = int.Parse(command[1]);
                    index += length;
                    if (index >= neighborhood.Count)
                    {
                        index = 0;
                    }
                    if (neighborhood[index] == 0)
                    {

                        Console.WriteLine($"Place {index} already had Valentine's day.");
                    }
                    else
                    {
                        neighborhood[index] -= 2;
                        if (neighborhood[index] <= 0)
                        {
                            neighborhood[index] = 0;
                            Console.WriteLine($"Place {index} has Valentine's day.");
                        }
                    }
                }
                command = Console.ReadLine().Split();
            }
            int counter = 0;
            Console.WriteLine($"Cupid's last position was {index}.");
            foreach (var item in neighborhood)
            {
                if(item != 0)
                {
                    counter++;
                }
            }
            if(counter ==0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {counter} places.");
            }
        }
    }
}
