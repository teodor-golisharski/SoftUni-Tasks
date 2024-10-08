using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] seqNum = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<string> strings = new List<string>();
            string input = Console.ReadLine();
            while (input != "find")
            {
                StringBuilder decrypted = new StringBuilder();
                int index = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    int currAscii = (int)input[i] - seqNum[index];
                    decrypted.Append((char)currAscii);
                    index++;
                    if (index == seqNum.Length)
                    {
                        index = 0;
                    }
                }
                Regex regexType = new Regex(@"\&(?<type>[A-Za-z]+)\&");
                Regex regexCord = new Regex(@"\<(?<cord>\w+)\>");
                Match matchType = regexType.Match(decrypted.ToString());
                Match matchCord = regexCord.Match(decrypted.ToString());
                string type = matchType.Groups["type"].Value.ToString();
                string cord = matchCord.Groups["cord"].Value.ToString();
                Console.WriteLine($"Found {type} at {cord}");
                input = Console.ReadLine();
            }
        }
    }
}
