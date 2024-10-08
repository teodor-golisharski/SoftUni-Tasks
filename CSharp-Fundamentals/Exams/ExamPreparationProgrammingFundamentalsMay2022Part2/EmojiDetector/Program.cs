using System;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Linq;

namespace EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(\:{2}[A-Z][a-z]{2,}\:{2})|(\*{2}[A-Z][a-z]{2,}\*{2})";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            int emojisCounter = matches.Count;
            BigInteger threshold = 1;
            foreach (var item in input)
            {
                if (char.IsDigit(item))
                {
                    int a = int.Parse(item.ToString());
                    threshold *= a;
                }
            }
            Console.WriteLine($"Cool threshold: {threshold}");
            Console.WriteLine($"{emojisCounter} emojis found in the text. The cool ones are:");
            foreach (var item in matches)
            {
                int coolness = 0;
                foreach (char letter in item.ToString())
                {
                    if (char.IsLetter(letter))
                    {
                        coolness += (int)letter;
                    }
                }
                if (coolness > threshold)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
