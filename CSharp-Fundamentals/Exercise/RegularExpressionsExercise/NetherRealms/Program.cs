using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            string healthPattern = @"[^\+\-\*\/\.,0-9]";
            string damagePattern = @"-?\d+\.?\d*";
            string multiplyPattern = @"[\*\/]";
            string splitPattern = @"[,\s]+";
            string input = Console.ReadLine();
            string[] demons = Regex.Split(input, splitPattern).OrderBy(x => x).ToArray();
            for (int i = 0; i < demons.Length; i++)
            {
                string currentDemon = demons[i];
                MatchCollection healthMatches = Regex.Matches(currentDemon, healthPattern);
                int health = 0;
                foreach (Match match in healthMatches)
                {
                    char currentChar = char.Parse(match.ToString());
                    health += (int)currentChar;
                }
                double damage = 0;
                MatchCollection damageMatches = Regex.Matches(currentDemon, damagePattern);
                foreach (Match match in damageMatches)
                {
                    double currentDamage = double.Parse(match.ToString());
                    damage += currentDamage;
                }
                MatchCollection multiplyMatches = Regex.Matches(currentDemon, multiplyPattern);
                foreach (Match match in multiplyMatches)
                {
                    char currentOperator = char.Parse(match.ToString());
                    if (currentOperator == '*')
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }
                Console.WriteLine($"{currentDemon} - {health} health, {damage:f2} damage");
            }
        }
    }
}