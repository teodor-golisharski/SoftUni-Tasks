using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> information = new Dictionary<string, List<string>>();
            string[] input = Console.ReadLine().Split(" -> ");
            while (input[0] != "End")
            {
                string company = input[0];
                if (!information.ContainsKey(company))
                {
                    information.Add(company, new List<string>());
                }
                if (!information[company].Contains(input[1]))
                {
                    information[company].Add(input[1]);
                }

                input = Console.ReadLine().Split(" -> ");
            }
            foreach (var item in information)
            {
                Console.WriteLine(item.Key);
                foreach (var id in item.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
