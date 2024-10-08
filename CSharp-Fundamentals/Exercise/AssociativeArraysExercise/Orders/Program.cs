using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            //    List<Product> reg = new List<Product>();
            //    string[] command = Console.ReadLine().Split();
            //    while (command[0] != "buy")
            //    {
            //        string name = command[0];
            //        double price = double.Parse(command[1]);
            //        int quantity = int.Parse(command[2]);
            //        Product product = new Product()
            //        {
            //            Name = name,
            //            Price = price,
            //            Quantity = quantity
            //        };
            //        bool existence = reg.Any(x => x.Name == name);
            //        int index = reg.FindIndex(x => x.Name == name);
            //        if (existence)
            //        {
            //            reg[index].Quantity += quantity;
            //            reg[index].Price = price;
            //        }
            //        else
            //        {
            //            reg.Add(product);
            //        }
            //        command = Console.ReadLine().Split();
            //    }
            //    foreach (var item in reg)
            //    {
            //        Console.WriteLine($"{item.Name} -> {item.Price * item.Quantity:f2}");
            //    }

            Dictionary<string, double> price = new Dictionary<string, double>();
            Dictionary<string, int> quantity = new Dictionary<string, int>();
            string[] command = Console.ReadLine().Split();
            while (command[0] != "buy")
            {
                if (!price.ContainsKey(command[0]))
                {
                    price.Add(command[0], double.Parse(command[1]));
                    quantity.Add(command[0], int.Parse(command[2]));
                }
                else
                {
                    price[command[0]] = double.Parse(command[1]);
                    quantity[command[0]] += int.Parse(command[2]);
                }
                command = Console.ReadLine().Split();
            }
            foreach (var item in price)
            {
                double sum = item.Value * quantity[item.Key];
                Console.WriteLine($"{item.Key} -> {sum:f2}");
            }

        }
    }
    //class Product
    //{
    //    public string Name { get; set; }
    //    public double Price { get; set; }
    //    public int Quantity { get; set; }
    //}
}
