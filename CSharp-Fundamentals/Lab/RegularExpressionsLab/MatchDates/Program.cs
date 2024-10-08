using System;
using System.Text.RegularExpressions;

namespace MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<day>[0-3][0-9])([/\-.])(?<month>[A-Z][a-z]{2})\1(?<year>[0-9]{4})";
            Regex regex = new Regex(pattern);
            string input = Console.ReadLine();
            MatchCollection matches = regex.Matches(input);
            foreach (Match item in matches)
            {
                string day = item.Groups["day"].Value;
                string month = item.Groups["month"].Value;
                string year = item.Groups["year"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
