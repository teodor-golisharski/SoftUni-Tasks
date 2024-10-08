using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> mirrorWords = new Dictionary<string, string>();
            string pattern = @"(\@|\#)(?<wordOne>[A-Za-z]{3,})\1{2}(?<wordTwo>[A-Za-z]{3,})\1";
            Regex regex = new Regex(pattern);
            string input = Console.ReadLine();
            MatchCollection matches = regex.Matches(input);
            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
                foreach (Match item in matches)
                {
                    string firstWord = item.Groups["wordOne"].Value;
                    string secondWord = item.Groups["wordTwo"].Value;
                    string reversed = "";
                    for (int i = secondWord.Length - 1; i >= 0; i--)
                    {
                        reversed += secondWord[i];
                    }
                    if (firstWord == reversed)
                    {
                        mirrorWords.Add(firstWord, secondWord);
                    }
                }
                if (mirrorWords.Count == 0)
                {
                    Console.WriteLine("No mirror words!");
                }
                else
                {
                    Console.WriteLine("The mirror words are:");
                    List<string> listed = new List<string>();
                    foreach (var item in mirrorWords)
                    {
                        string s = $"{item.Key} <=> {item.Value}";
                        listed.Add(s);
                    }
                    Console.WriteLine(string.Join(", ", listed));
                }
            }
        }
    }
}
