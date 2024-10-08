using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PostOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('|');
            string firstPart = input[0];
            string secondPart = input[1];
            string thirdPart = input[2];
            string pattern1 = @"([\#\$\%\*\&])(?<Caps>[A-Z])+\1";
            string pattern2 = @"(?<asciiCode>[0-9]{2})\:(?<length>[0-2][0-9])";
            string pattern3 = @"\b[A-Z]\S+\b";
            Regex regex1 = new Regex(pattern1);
            Regex regex2 = new Regex(pattern2);
            Regex regex3 = new Regex(pattern3);

            //PartOne
            Match matches1 = regex1.Match(firstPart);
            string match1 = matches1.ToString().Substring(1, matches1.Length - 2);
            List<char> caps = new List<char>();
            foreach (var item in match1)
            {
                caps.Add(item);
            }

            //PartTwo
            MatchCollection matches2 = regex2.Matches(secondPart);
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < match1.Length; i++)
            {
                char currentCap = match1[i];
                for (int j = 0; j < matches2.Count; j++)
                {
                    int asciicode = int.Parse(matches2[j].Groups["asciiCode"].Value);
                    int length = int.Parse(matches2[j].Groups["length"].Value);
                    if ((int)currentCap == asciicode)
                    {
                        dict.Add(asciicode, length); break;
                    }
                }
            }

            //PartThree
            MatchCollection matches3 = regex3.Matches(thirdPart);
            for (int i = 0; i < match1.Length; i++)
            {
                foreach (var item in matches3)
                {
                    string word = item.ToString();
                    int fisrtCaseCode = (int)word[0];
                    if (caps[i] == word[0])
                    {
                        if (dict.ContainsKey(fisrtCaseCode) && dict[fisrtCaseCode] == word.Length - 1)
                        {
                            Console.WriteLine(word);
                        }
                    }
                }
            }
        }
    }
}
