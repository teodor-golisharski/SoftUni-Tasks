using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<exp>[^0-9])+(?<digit>\d+)";
            Regex regex = new Regex(pattern);
            string input = Console.ReadLine();
            MatchCollection matches = regex.Matches(input);
            StringBuilder result = new StringBuilder();
            int count = 0;
            foreach (Match match in matches)
            {
                string matchedExp = match.Value;
                string exp = string.Empty;
                foreach (char item in matchedExp)
                {
                    if (char.IsDigit(item))
                    {
                        break;
                    }
                    exp += char.ToUpper(item);

                }
                int digit = int.Parse(match.Groups["digit"].Value);
                for (int i = 0; i < digit; i++)
                {
                    result.Append(exp);
                }
            }
            count = result.ToString().Distinct().Count();
            Console.WriteLine($"Unique symbols used: {count}");
            Console.WriteLine(result);
        }
    }
}