using System;
using System.Collections.Generic;

namespace OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);
                Person person = new Person()
                {
                    Name = name,
                    Age = age
                };
                family.AddMember(person);
            }
            Person oldest = family.GetOldestMember();
            Console.WriteLine(oldest.Name + " " + oldest.Age);
        }
    }

    class Family
    {
        public Family()
        {
            this.People = new List<Person>();
        }
        public List<Person> People { get; set; }
        public void AddMember(Person member)
        {
            People.Add(member);
        }
        public Person GetOldestMember()
        {
            int maxAge = int.MinValue;
            string nameOfOldest = string.Empty;
            foreach (var item in this.People)
            {
                if (item.Age > maxAge)
                {
                    maxAge = item.Age;
                    nameOfOldest = item.Name;
                }
            }
            Person oldest = new Person();
            {
                oldest.Name = nameOfOldest;
                oldest.Age = maxAge;
            }
            return oldest;
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
