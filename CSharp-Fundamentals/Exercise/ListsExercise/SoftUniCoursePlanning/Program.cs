using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> course = Console.ReadLine().Split(", ").ToList();
            string[] input = Console.ReadLine().Split(':');
            while (input[0] != "course start")
            {
                switch (input[0])
                {
                    case "Add":
                        if (!course.Contains(input[1]))
                        {
                            course.Add(input[1]);
                        }
                        break;

                    case "Insert":
                        if (int.Parse(input[2]) < 0 || int.Parse(input[2]) >= course.Count)
                        {
                            break;
                        }
                        else if (!course.Contains(input[1]))
                        {
                            course.Insert(int.Parse(input[2]), input[1]);
                        }
                        break;

                    case "Remove":
                        if (course.Contains(input[1]))
                        {
                            course.Remove(input[1]);
                        }
                        else if (course.Contains(input[1] + "-Exercise"))
                        {
                            course.Remove(input[1] + "-Exercise");
                        }
                        break;

                    case "Swap":
                        if (course.Contains(input[1]) && course.Contains(input[2]))
                        {
                            int a1 = course.IndexOf(input[1]);
                            int a2 = course.IndexOf(input[2]);
                            if (course.Contains(input[1]) && course.Contains(input[2]))
                            {
                                string temp = course.ElementAt(a1);
                                course[a1] = course[a2];
                                course[a2] = temp;
                            }
                            if (course.Contains(input[1] + "-Exercise") && course.Contains(course[a1]))
                            {
                                a1 = course.IndexOf(input[1]);
                                course.Remove(input[1] + "-Exercise");
                                course.Insert(a1 + 1, input[1] + "-Exercise");
                            }
                            else if (course.Contains(input[2] + "-Exercise") && course.Contains(course[a2]))
                            {
                                a1 = course.IndexOf(input[2]);
                                course.Remove(input[2] + "-Exercise");
                                course.Insert(a1 + 1, input[2] + "-Exercise");
                            }
                        }
                        break;

                    case "Exercise":
                        course = Exercise(course, input); break;
                        
                }
                input = Console.ReadLine().Split(':');
            }
            for (int i = 0; i < course.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{course[i]}");
            }
        }
        static List<string> Exercise(List<string> course, string[] input)
        {
            string lesson = input[1];
            if (course.Contains(lesson) && !course.Contains(lesson + "-Exercise"))
            {
                int index = course.IndexOf(lesson);
                course.Insert(index + 1, lesson + "-Exercise");
            }
            else if (!course.Contains(lesson))
            {
                course.Add(lesson);
                course.Add(lesson + "-Exercise");
            }
            return course;
        }
    }
}
