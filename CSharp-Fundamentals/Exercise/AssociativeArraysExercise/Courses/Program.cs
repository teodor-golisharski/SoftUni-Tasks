using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string[] input = Console.ReadLine().Split(" : ");
            while (input[0] != "end")
            {
                string currentCourse = input[0];
                string currentStudent = input[1];
                bool existence = courses.Any(x => x.Key == currentCourse);
                if (!courses.ContainsKey(currentCourse))
                {
                    courses[currentCourse] = new List<string>();
                }
                courses[currentCourse].Add(currentStudent);
                input = Console.ReadLine().Split(" : ");
            }
            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                foreach (var students in item.Value)
                {
                    Console.WriteLine($"-- {students}");
                }
            }
        }
    }
}
