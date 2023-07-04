using System;
using System.Linq;
using System.Collections.Generic;

namespace RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] s = Console.ReadLine().Split();
            Random rand = new Random();
            for (int i = 0; i < s.Length; i++)
            {
                int randomIndex = rand.Next(0, s.Length);
                string current = s[i];
                s[i] = s[randomIndex];
                s[randomIndex] = current;
            }
            foreach (var item in s)
            {
                Console.WriteLine(item);
            }
        }
    }
}
