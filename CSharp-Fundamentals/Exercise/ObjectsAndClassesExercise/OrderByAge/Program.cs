using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> data = new List<Person>();
            string[] input = Console.ReadLine().Split();
            while (input[0] != "End")
            {
                string name = input[0];
                string id = input[1];
                int age = int.Parse(input[2]);
                bool flag = true;
                Person current = new Person(name, id, age);
                foreach (var item in data)
                {
                    if(item.ID == current.ID)
                    {
                        item.Name = current.Name;
                        item.Age = current.Age;
                        flag = false;
                        break;
                    }
                }
                if(flag)
                {
                    data.Add(current);
                }
                input = Console.ReadLine().Split();
            }
            data = data.OrderBy(x => x.Age).ToList();
            foreach (var item in data)
            {
                Console.WriteLine($"{item.Name} with ID: {item.ID} is {item.Age} years old.");
            }
            {

            }
        }
    }
    class Person
    {
        public Person(string name, string id, int age)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;
        }
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
    }
}
