using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> dict = new Dictionary<string, List<decimal>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                decimal currentGrade = decimal.Parse(input[1]);
                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new List<decimal> { currentGrade });
                }
                else
                {
                    dict[name].Add(currentGrade);
                }
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {string.Join(" ", item.Value.Select(grade => grade.ToString("F2")))} (avg: {item.Value.Average():f2})");
            }
        }
    }
}
