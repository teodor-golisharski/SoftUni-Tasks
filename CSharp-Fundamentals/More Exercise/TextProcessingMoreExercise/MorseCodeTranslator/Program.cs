using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> morseAlpha = new List<string>() { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
            string[] latinAlpha = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            string[] morse = Console.ReadLine().Split(" | ").ToArray();
            StringBuilder result = new StringBuilder();

            foreach (string item in morse)
            {
                foreach (string letter in item.Split(" ", StringSplitOptions.RemoveEmptyEntries))
                {
                    int index = morseAlpha.IndexOf(letter);
                    result.Append(latinAlpha[index]);
                }
                result.Append(" ");
            }
            Console.WriteLine(result.ToString().ToUpper());
        }
    }
}
