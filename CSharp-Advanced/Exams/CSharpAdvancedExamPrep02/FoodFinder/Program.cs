using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string> { "pear", "flour", "pork", "olive" };

            HashSet<char> containingLetters = new HashSet<char>();

            Queue<char> vowels = new Queue<char>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray());
            Stack<char> consonants = new Stack<char>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray());

            while (consonants.Count != 0)
            {
                char currentVowel = vowels.Dequeue();
                char currentConsonant = consonants.Pop();
                foreach (var word in words)
                {
                    foreach (var item in word)
                    {
                        if (item == currentVowel)
                        {
                            containingLetters.Add(item);
                        }
                        if(item == currentConsonant)
                        {
                            containingLetters.Add(item);
                        }
                    }
                }
                vowels.Enqueue(currentVowel);
            }
            List<string> result = new List<string>();
            int count = 0;
            for (int i = 0; i < words.Count; i++)
            {
                string current = words[i];
                string s = "";
                for (int j = 0; j < current.Length; j++)
                {
                    foreach (var item in containingLetters)
                    {
                        if (current[j] == item)
                        {
                            s += current[j];
                            break;
                        }
                    }
                }
                if(s == current)
                {
                    result.Add(current);
                    count++;
                }
            }
            Console.WriteLine($"Words found: {count}");
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
