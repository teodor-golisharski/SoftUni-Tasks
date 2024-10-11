using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] peopleInfo = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < peopleInfo.Length; i++)
            {
                string name = peopleInfo[i].Split('=')[0];
                double money = double.Parse(peopleInfo[i].Split('=')[1]);
                try
                {
                    Person person = new Person(name, money);
                    people.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string[] productsInfo = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < productsInfo.Length; i++)
            {
                string name = productsInfo[i].Split('=')[0];
                double cost = double.Parse(productsInfo[i].Split('=')[1]);
                try
                {
                    Product product = new Product(name, cost);
                    products.Add(product);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "END")
            {
                foreach (var item in people)
                {
                    if(item.Name == command[0])
                    {
                        item.BuyProduct(products.Find(x => x.Name == command[1]));
                    }
                }
                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var item in people)
            {
                item.Report();
            }
        }
    }
}
