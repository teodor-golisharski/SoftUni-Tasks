using System;
using System.Collections.Generic;

namespace Students
{
    class Program
    {
        static bool Existance(List<Student> data, string firstName, string lastName)
        {
            foreach (Student item in data)
            {
                if (item.FirstName == firstName && item.LastName == lastName)
                {
                    return true;
                }
            }
            return false;
        }
        static Student GetStudent(List<Student> data, string firstName, string lastName)
        {
            Student result = null;
            foreach (Student item in data)
            {
                if (item.FirstName == firstName && item.LastName == lastName)
                {
                    result = item;

                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            List<Student> data = new List<Student>();
            string[] input = Console.ReadLine().Split();
            while (input[0] != "end")
            {
                string firstName = input[0];
                string lastName = input[1];
                int age = int.Parse(input[2]);
                string city = input[3];

                if (Existance(data, firstName, lastName))
                {
                    Student student = GetStudent(data, firstName, lastName);
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.City = city;
                }
                else
                {
                    Student student = new Student()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        City = city
                    };
                    data.Add(student);
                }
                input = Console.ReadLine().Split();
            }
            string filter = Console.ReadLine();
            foreach (Student item in data)
            {
                if(item.City == filter)
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName} is {item.Age} years old.");
                }
            }
        }
    }
    class Student
    {
        public Student()
        {

        }
        public Student(string firstName, string lastName, int age, string city)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.City = city;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
}
