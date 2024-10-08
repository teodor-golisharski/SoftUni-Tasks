using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([\/=])(?<dest>[A-Z][A-Za-z]{2,})\1";
            Regex regex = new Regex(pattern);
            string input = Console.ReadLine();
            MatchCollection matches = regex.Matches(input);
            string[] dest = matches.Select(x => x.Groups["dest"].Value).ToArray();
            int travelPoints = matches.Sum(x => x.Length - 2);
            Console.WriteLine($"Destinations: {string.Join(", ", dest)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
