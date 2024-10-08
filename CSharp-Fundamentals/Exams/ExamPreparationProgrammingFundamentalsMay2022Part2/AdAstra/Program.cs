using System;
using System.Text.RegularExpressions;

namespace AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([#|\|])(?<itemName>[A-Za-z\s]+)\1(?<expirationDate>[0-3][0-9]\/[0-1][0-9]\/[0-9]{2})\1(?<cal>[0-9]+)\1";
            Regex regex = new Regex(pattern);
            int totalCalories = 0;
            string text = Console.ReadLine();
            MatchCollection matches = regex.Matches(text);
            foreach (Match item in matches)
            {
                totalCalories += int.Parse(item.Groups["cal"].Value);
            }
            int days = totalCalories / 2000;
            Console.WriteLine($"You have food to last you for: {days} days!");
            foreach (Match item in matches)
            {
                Console.WriteLine($"Item: {item.Groups["itemName"].Value}, Best before: {item.Groups["expirationDate"].Value}, Nutrition: {item.Groups["cal"].Value}");
            }
        }
    }
}
