using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Employee> data = new List<Employee>();
            List<string> departments = new List<string>();
            List<Employee> target = new List<Employee>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                double salary = double.Parse(input[1]);
                string department = input[2];
                Employee employee = new Employee(name, salary, department);
                data.Add(employee);
            }
            string targetDep = string.Empty;
            double avg = double.MinValue;
            foreach (var item in data)
            {
                if (!departments.Contains(item.Department))
                {
                    departments.Add(item.Department);
                }
            }
            foreach (var dp in departments)
            {
                double sum = 0;
                int count = 0;
                foreach (var item in data)
                {
                    if (item.Department == dp)
                    {
                        sum += item.Salary;
                        count++;
                        target.Add(item);
                    }
                }
                if (avg < (sum / count))
                {
                    target.RemoveAll(x => x.Department != dp);
                    avg = sum / count;
                    targetDep = dp; 
                }
                else
                {
                    target.RemoveAll(x => x.Department == dp);
                }
            }
            var result = target.OrderByDescending(x => x.Salary);

            Console.WriteLine($"Highest Average Salary: {targetDep}");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name} {item.Salary:f2}");
            }
        }
        class Employee
        {
            public Employee(string name, double salary, string department)
            {
                Name = name;
                Salary = salary;
                Department = department;
            }

            public string Name { get; set; }
            public double Salary { get; set; }
            public string Department { get; set; }
        }
    }
}
