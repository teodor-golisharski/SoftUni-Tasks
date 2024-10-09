using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                string contestName = input.Split(':')[0];
                string contestPass = input.Split(':')[1];
                contests.Add(contestName, contestPass);
                input = Console.ReadLine();
            }
            Dictionary<string, Dictionary<string, int>> results = new Dictionary<string, Dictionary<string, int>>();
            string submissions = Console.ReadLine();
            while (submissions != "end of submissions")
            {
                string[] tokens = submissions.Split("=>");
                string contest = tokens[0];
                string password = tokens[1];
                string candidate = tokens[2];
                int points = int.Parse(tokens[3]);
                if (Validation(contests, contest, password))
                {
                    if (results.ContainsKey(candidate))
                    {
                        if (results[candidate].ContainsKey(contest))
                        {
                            if (results[candidate][contest] < points)
                            {
                                results[candidate][contest] = points;
                            }
                        }
                        else
                        {
                            results[candidate].Add(contest, points);
                        }
                    }
                    else
                    {
                        results.Add(candidate, new Dictionary<string, int>());
                        results[candidate].Add(contest, points);
                    }
                }
                submissions = Console.ReadLine();
            }
            int maxPoints = int.MinValue;
            string bestCandidate = string.Empty;
            foreach (var item in results)
            {
                int currentPoints = 0;
                foreach (var pts in item.Value)
                {
                    currentPoints += pts.Value;
                }
                if (currentPoints > maxPoints)
                {
                    maxPoints = currentPoints;
                    bestCandidate = item.Key;
                }
            }
            Console.WriteLine($"Best candidate is {bestCandidate} with total {maxPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var candidates in results.OrderBy(x => x.Key))
            {
                Console.WriteLine(candidates.Key);
                foreach (var item in candidates.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
        static bool Validation(Dictionary<string, string> contests, string contest, string password)
        {
            if (contests.ContainsKey(contest))
            {
                if (contests[contest] == password)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
