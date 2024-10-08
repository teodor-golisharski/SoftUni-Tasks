using System;

namespace ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length - 1; i++)
            {
                char s1 = input[i];
                char s2 = input[i + 1];
                if (s1 == s2)
                {
                    input = input.Remove(i + 1, 1);
                    i--;
                }
            }
            Console.WriteLine(input);
        }
    }
}
