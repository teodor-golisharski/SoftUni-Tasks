using System;
using System.Collections.Generic;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> data = new List<Student>();
            string[] input = Console.ReadLine().Split();
            while (input[0] != "end")
            {
                Student student = new Student(input[0], input[1], int.Parse(input[2]), input[3]);
                data.Add(student);
                input = Console.ReadLine().Split();
            }
            string filter = Console.ReadLine();
            foreach (Student item in data)
            {
                if(item.HomeTown == filter)
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName} is {item.Age} years old.");
                }
            }
        }
    }
    class Student
    {
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.HomeTown = homeTown;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}
