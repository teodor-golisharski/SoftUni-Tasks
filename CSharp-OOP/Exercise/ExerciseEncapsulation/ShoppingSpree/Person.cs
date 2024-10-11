using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();
        }

        private string name;
        private double money;
        private List<Product> bagOfProducts;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public double Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }
        
        public void BuyProduct(Product product)
        {
            if(this.money >= product.Cost)
            {
                money -= product.Cost;
                bagOfProducts.Add(product);
                Console.WriteLine($"{name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{name} can't afford {product.Name}");
            }
        }
        public void Report()
        {
            if(bagOfProducts.Count > 0)
            {
                List<string> display = new List<string>();
                foreach(Product product in bagOfProducts)
                {
                    display.Add(product.Name);
                }
                Console.WriteLine($"{name} - {string.Join(", ", display)}");
               
            }
            else if(bagOfProducts.Count == 0)
            {
                Console.WriteLine($"{name} - Nothing bought");
            }
        }
    }
}
