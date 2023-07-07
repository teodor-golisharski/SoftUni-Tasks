using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> data = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                string[] s = Console.ReadLine().Split();
                string firstName = s[0];
                string lastName = s[1];
                double grade = double.Parse(s[2]);
                Student student = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Grade = grade
                };
                data.Add(student);
            }
            foreach (Student item in data.OrderByDescending(s => s.Grade))
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}: {item.Grade:f2}");
            }
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public Student()
        {

        }
        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

    }
}
