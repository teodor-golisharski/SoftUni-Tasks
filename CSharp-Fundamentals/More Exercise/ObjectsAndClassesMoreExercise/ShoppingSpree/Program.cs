using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            string[] readPeople = Console.ReadLine().Split(";");
            for (int i = 0; i < readPeople.Length; i++)
            {
                string[] currentPerson = readPeople[i].Split("=");
                string name = currentPerson[0];
                double money = double.Parse(currentPerson[1]);
                Person person = new Person()
                {
                    Name = name,
                    Money = money
                };
                people.Add(person);
            }
            string[] readProducts = Console.ReadLine().Split(";");
            for (int i = 0; i < readProducts.Length; i++)
            {
                string[] currentProduct = readProducts[i].Split("=");
                string name = currentProduct[0];
                double cost = double.Parse(currentProduct[1]);
                Product product = new Product()
                {
                    Name = name,
                    Cost = cost
                };
                products.Add(product);
            }
            string[] input = Console.ReadLine().Split();
            while (input[0] != "END")
            {
                string name = input[0];
                string product = input[1];
                int personIndex = FindPersonIndex(people, name);
                int productIndex = FindProductIndex(products, product);
                if (people[personIndex].Money >= products[productIndex].Cost)
                {
                    people[personIndex].Money -= products[productIndex].Cost;
                    people[personIndex].BagOfProducts.Add(products[productIndex]);
                    Console.WriteLine($"{people[personIndex].Name} bought {products[productIndex].Name}");
                }
                else
                {
                    Console.WriteLine($"{people[personIndex].Name} can't afford {products[productIndex].Name}");
                }
                input = Console.ReadLine().Split();
            }
            foreach (var item in people)
            {
                if (item.BagOfProducts.Count > 0)
                {
                    List<string> names = new List<string>();
                    foreach (var prods in item.BagOfProducts)
                    {
                        names.Add(prods.Name);
                    }
                    Console.WriteLine($"{item.Name} - {string.Join(", ", names)}");
                }
                else
                {
                    Console.WriteLine($"{item.Name} - Nothing bought");
                }
            }
        }
        static int FindPersonIndex(List<Person> people, string name)
        {
            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].Name == name)
                {
                    return i;
                }
            }
            return 0;
        }
        static int FindProductIndex(List<Product> products, string product)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if(products[i].Name == product)
                {
                    return i;
                }
            }
            return 0;
        }
    }

    class Person
    {
        public Person()
        {
            this.BagOfProducts = new List<Product>();
        }
        public Person(string name, double money)
        {
            Name = name;
            Money = money;

        }
        public string Name { get; set; }
        public double Money { get; set; }
        public List<Product> BagOfProducts { get; set; }
    }

    class Product
    {
        public Product()
        {

        }
        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }
        public string Name { get; set; }
        public double Cost { get; set; }
    }
}
