using System;
using System.Collections.Generic;
using System.Linq;

namespace Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contestStats = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> individualStats = new Dictionary<string, int>();
            string[] input = Console.ReadLine().Split(" -> ");
            while (input[0] != "no more time")
            {
                string username = input[0];
                string contest = input[1];
                int points = int.Parse(input[2]);
                if (contestStats.ContainsKey(contest))
                {
                    if (!contestStats[contest].ContainsKey(username))
                    {
                        contestStats[contest][username] = 0;
                    }
                    if (points > contestStats[contest][username])
                    {
                        contestStats[contest][username] = points;
                    }
                    
                }
                if (!contestStats.ContainsKey(contest))
                {
                    contestStats.Add(contest, new Dictionary<string, int>());
                    contestStats[contest].Add(username, points);
                }
                input = Console.ReadLine().Split(" -> ");
            }
            foreach (var item in contestStats)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count} participants");
                int count = 1;
                foreach (var users in item.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    if (individualStats.ContainsKey(users.Key))
                    {
                        individualStats[users.Key] += users.Value;
                    }
                    else
                    {
                        individualStats.Add(users.Key, users.Value);
                    }
                    Console.WriteLine($"{count}. {users.Key} <::> {users.Value}");
                    count++;
                }
            }
            Console.WriteLine("Individual standings:");
            int counts = 1;
            foreach (var item in individualStats.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{counts}. {item.Key} -> {item.Value}");
                counts++;
            }
        }
    }
}
