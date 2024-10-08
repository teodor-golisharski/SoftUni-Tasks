using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b[A-Z][a-z]+\b \b[A-Z][a-z]+\b";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            Console.WriteLine(string.Join(" ", matches));
        }
    }
}
