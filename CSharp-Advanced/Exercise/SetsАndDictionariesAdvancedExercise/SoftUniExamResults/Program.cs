using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> submissions = new Dictionary<string, int>();
            Dictionary<string, Dictionary<string, int>> results = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            while (input != "exam finished")
            {
                string[] tokens = input.Split("-");
                string username = tokens[0];
                if (tokens[1] == "banned")
                {
                    results.Remove(username);
                }
                else
                {
                    string language = tokens[1];
                    if (submissions.ContainsKey(language))
                    {
                        submissions[language]++;
                    }
                    else
                    {
                        submissions.Add(language, 1);
                    }
                    int points = int.Parse(tokens[2]);

                    if (!results.ContainsKey(username))
                    {
                        results.Add(username, new Dictionary<string, int>());
                        results[username].Add(language, points);
                    }
                    else
                    {
                        if (results[username].ContainsKey(language))
                        {
                            if (results[username][language] < points)
                            {
                                results[username][language] = points;
                            }
                        }
                        else
                        {
                            results[(username)].Add(language, points);
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Results:");
            foreach (var person in results.OrderByDescending(x => x.Value.Values.Max()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{person.Key} | {person.Value.Values.Max()}");
            }
            Console.WriteLine("Submissions:");
            foreach (var item in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
