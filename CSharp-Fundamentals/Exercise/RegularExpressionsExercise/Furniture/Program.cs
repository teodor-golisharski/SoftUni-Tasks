using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<name>[A-Za-z\s]+)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)";
            string input = Console.ReadLine();
            double total = 0;
            List<string> bought = new List<string>();
            while (input != "Purchase")
            {
                Match matches = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
                if(matches.Success)
                {
                    string name = matches.Groups["name"].Value;
                    double price = double.Parse(matches.Groups["price"].Value);
                    int quantity = int.Parse(matches.Groups["quantity"].Value);
                    bought.Add(name);
                    total += price*quantity;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Bought furniture:");
            foreach (var item in bought)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {total:f2}");
        }
    }
}
