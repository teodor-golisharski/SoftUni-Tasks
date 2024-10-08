using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex patternName = new Regex(@"(?<name>[A-Za-z])");
            Regex patternDigits = new Regex(@"(?<digits>\d+)");
            Dictionary<string, int> participants = new Dictionary<string, int>();

            string[] input = Console.ReadLine().Split(", ");

            List<string> racers = new List<string>();
            foreach (var item in input)
            {
                racers.Add(item);
            }
            string command = Console.ReadLine();
            while (command != "end of race")
            {
                int sum = 0;
                MatchCollection matchName = patternName.Matches(command);
                MatchCollection matchDigits = patternDigits.Matches(command);
                string s = string.Join("", matchName);
                string d = string.Join("", matchDigits);
                for (int i = 0; i < d.Length; i++)
                {
                    sum += int.Parse(d[i].ToString());
                }
                if (racers.Contains(s) && !participants.ContainsKey(s))
                {
                    participants.Add(s, sum);
                }
                else if (racers.Contains(s) && participants.ContainsKey(s))
                {
                    participants[s] += sum;
                }
                command = Console.ReadLine();
            }
            var winners = participants.OrderByDescending(x => x.Value).Take(3);
            var first = winners.Take(1);
            var second = winners.OrderByDescending(x => x.Value).Take(2).OrderBy(x => x.Value).Take(1);
            var third = winners.OrderBy(x => x.Value).Take(1);
            foreach (var item in first)
            {
                Console.WriteLine($"1st place: {item.Key}");
            }
            foreach (var item in second)
            {
                Console.WriteLine($"2nd place: {item.Key}");
            }
            foreach (var item in third)
            {
                Console.WriteLine($"3rd place: {item.Key}");
            }
        }
    }
}
