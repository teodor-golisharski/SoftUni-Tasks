using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestsCollection = new Dictionary<string, string>();
            string[] input = Console.ReadLine().Split(':');
            while (input[0] != "end of contests")
            {
                contestsCollection.Add(input[0], input[1]);
                input = Console.ReadLine().Split(':');
            }
            Dictionary<string, Dictionary<string, int>> results = new Dictionary<string, Dictionary<string, int>>();
            string[] data = Console.ReadLine().Split("=>");
            while (data[0] != "end of submissions")
            {
                string contest = data[0];
                string password = data[1];
                string username = data[2];
                int points = int.Parse(data[3]);
                bool contestValidation = contestsCollection.ContainsKey(contest);
                bool passwordValidation = contestsCollection.ContainsValue(password);
                if (contestValidation && passwordValidation)
                {
                    if (!results.ContainsKey(username))
                    {
                        results[username] = new Dictionary<string, int>();
                    }
                    if (results.ContainsKey(username) && !results[username].ContainsKey(contest))
                    {
                        results[username][contest] = 0;
                    }
                    if (results[username][contest] < points)
                    {
                        results[username][contest] = points;
                    }
                }
                data = Console.ReadLine().Split("=>");
            }
            int max = int.MinValue;
            string bestName = string.Empty;

            foreach (var item in results)
            {
                int sum = 0;
                foreach (var stats in item.Value)
                {
                    sum += stats.Value;
                }
                if (sum > max)
                {
                    bestName = item.Key;
                    max = sum;
                }
            }
            Console.WriteLine($"Best candidate is {bestName} with total {max} points.");
            Console.WriteLine("Ranking: ");
            foreach (var item in results.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                foreach (var stats in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {stats.Key} -> {stats.Value}");
                }
            }
        }
    }
}

