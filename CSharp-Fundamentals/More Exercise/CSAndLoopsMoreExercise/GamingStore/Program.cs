using System;

namespace GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            // OutFall 4                   $39.99
            // CS: OG                      $15.99
            // Zplinter Zell	           $19.99
            // Honored 2                   $59.99
            // RoverWatch                  $29.99
            // RoverWatch Origins Edition  $39.99

            double balance = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            double price = 0;
            double receipt = 0;
            while (input != "Game Time")
            {
                switch (input)
                {
                    case "OutFall 4": price = 39.99; break;
                    case "CS: OG": price = 15.99; break;
                    case "Zplinter Zell": price = 19.99; break;
                    case "Honored 2": price = 59.99; break;
                    case "RoverWatch": price = 29.99; break;
                    case "RoverWatch Origins Edition": price = 39.99; break;
                    default: price = 0; break;
                }
                if (price == 0)
                {
                    Console.WriteLine("Not Found");
                    input = Console.ReadLine();
                    continue;
                }
                if(balance < price)
                {
                    Console.WriteLine($"Too Expensive");
                    input = Console.ReadLine();continue;
                }
                if (balance >= price)
                {
                    balance -= price;
                    receipt += price;
                    Console.WriteLine($"Bought {input}");
                }
                if(balance==0)
                {
                    Console.WriteLine("Out of money!");return;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total spent: ${receipt:f2}. Remaining: ${balance:f2}");
        }
    }
}
