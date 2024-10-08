using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex patternMatchesCount = new Regex(@"[starSTAR]");
            Regex finalPattern = new Regex(@"@(?<planetName>[A-Za-z]+)[^@\-!:>]*:(?<planetPopulation>\d+)[^@\-!:>]*!(?<attackType>A|D)![^@\-!:>]*->(?<soldierCount>\d+)");
            Dictionary<string, char> planets = new Dictionary<string, char>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string cryptedMessage = Console.ReadLine();
                MatchCollection matches = patternMatchesCount.Matches(cryptedMessage);
                int count = matches.Count;
                string decryptedMessage = string.Empty;
                for (int j = 0; j < cryptedMessage.Length; j++)
                {
                    int curr = (int)cryptedMessage[j] - count;
                    decryptedMessage += (char)curr;
                }
                Match match = finalPattern.Match(decryptedMessage);
                if (match.Success)
                {
                    string planetName = match.Groups["planetName"].Value;
                    int planetPopulation = int.Parse(match.Groups["planetPopulation"].Value);
                    char attackType = char.Parse(match.Groups["attackType"].Value);
                    int soldierCount = int.Parse(match.Groups["soldierCount"].Value);
                    planets.Add(planetName, attackType);
                }
            }
            int countAttacked = planets.Count(x => x.Value == 'A');
            int countDestroyed = planets.Count(x => x.Value == 'D');
            Console.WriteLine("Attacked planets: " + countAttacked);
            if (countAttacked > 0)
            {
                foreach (var item in planets.Where(x => x.Value == 'A').OrderBy(x => x.Key))
                {
                    Console.WriteLine($"-> {item.Key}");
                }
            }
            Console.WriteLine("Destroyed planets: " + countDestroyed);
            if (countDestroyed > 0)
            {
                foreach (var item in planets.Where(x => x.Value == 'D').OrderBy(x => x.Key))
                {
                    Console.WriteLine($"-> {item.Key}");
                }
            }
        }
    }
}
