using System;
using System.Linq;
using System.Collections.Generic;

namespace ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> products = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                products.Add(Console.ReadLine());
            }
            products.Sort();
            foreach (var item in products)
            {
                Console.WriteLine($"{products.IndexOf(item) + 1}.{item}");
            }
        }
    }
}
