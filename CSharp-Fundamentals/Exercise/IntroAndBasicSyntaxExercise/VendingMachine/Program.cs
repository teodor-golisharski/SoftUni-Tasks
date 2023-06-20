using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double balance = 0;
            double total = 0;
            while (input != "Start")
            {
                switch (input)
                {
                    case "0.1":
                    case "0.2":
                    case "0.5":
                    case "1":
                    case "2": balance += double.Parse(input); break;
                    default: Console.WriteLine($"Cannot accept {input}"); break;
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "End")
            {
                switch (input)
                {
                    case "Nuts": total = 2; break;
                    case "Water": total = 0.7; break;
                    case "Crisps": total = 1.5; break;
                    case "Soda": total = 0.8; break;
                    case "Coke": total = 1; break;
                    default:
                        Console.WriteLine("Invalid product");
                        input = Console.ReadLine();
                        continue;
                }
                if(balance>=total)
                {
                    balance -= total;
                    Console.WriteLine($"Purchased {input.ToLower()}");
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Change: {balance:f2}");
        }
    }
}
