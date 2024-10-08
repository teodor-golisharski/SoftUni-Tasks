using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parkingLot = new Dictionary<string, string>();
            int numOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split();
                string mainCommand = command[0];
                bool existance = parkingLot.Any(x => x.Key == command[1]);
                switch (mainCommand)
                {
                    case "register":
                        string username = command[1];
                        if (!existance)
                        {
                            parkingLot[username] = command[2];
                            Console.WriteLine($"{username} registered {command[2]} successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {command[2]}");
                        }
                        break;
                    case "unregister":
                        string user = command[1];
                        if (!existance)
                        {
                            Console.WriteLine($"ERROR: user {user} not found");
                        }
                        else
                        {
                            parkingLot.Remove(user);
                            Console.WriteLine($"{user} unregistered successfully");
                        }
                        break;
                }
            }
            foreach (var item in parkingLot)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
