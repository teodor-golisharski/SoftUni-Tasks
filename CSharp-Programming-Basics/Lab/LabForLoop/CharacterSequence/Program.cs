using System;

namespace CharacterSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            for (int i = 0; i < s.Length; i++)
            {
                char letter = s[i];
                Console.WriteLine(letter);
            }
        }
    }
}
