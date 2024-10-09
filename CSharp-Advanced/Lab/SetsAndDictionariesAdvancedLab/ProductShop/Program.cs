using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> dict = new Dictionary<string, Dictionary<string, double>>();
            string[] input = Console.ReadLine().Split(", ");
            while (input[0] != "Revision")
            {
                string shop = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);
                if(!dict.ContainsKey(shop))
                {
                    dict.Add(shop, new Dictionary<string, double>());
                    dict[shop].Add(product, price);
                }
                else
                {
                    if (!dict[shop].ContainsKey(product))
                    {
                        dict[shop].Add(product, price);
                    }
                    else
                    {
                        dict[shop][product] = price;
                    }
                }
                input = Console.ReadLine().Split(", ");
            }
            foreach (var shop in dict.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var item in shop.Value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }
        }
    }
}
