using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"^%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$");
            string input = Console.ReadLine();
            double totalIncome = 0;
            List<Purchase> purchases = new List<Purchase>();
            while (input != "end of shift")
            {
                Match match = pattern.Match(input);
                if(match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    double price = double.Parse(match.Groups["price"].Value);
                    totalIncome += price*count;
                    Purchase purchase = new Purchase(name, product, count, price);
                    purchases.Add(purchase);
                }
                input = Console.ReadLine();
            }
            foreach (var item in purchases)
            {
                Console.WriteLine($"{item.Name}: {item.Product} - {item.Count*item.Price:f2}");
            }
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
    class Purchase
    {
        public Purchase(string name, string product, int count, double price)
        {
            Name = name;
            Product = product;
            Count = count;
            Price = price;
        }
        public string Name { get; set; }
        public string Product { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }
}
