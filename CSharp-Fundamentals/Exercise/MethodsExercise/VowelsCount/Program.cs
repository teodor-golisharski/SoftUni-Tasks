using System;

namespace VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Console.WriteLine(Vowels(s));
        }
        static int Vowels(string s)
        {
            int sum = 0;
            s = s.ToLower();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'o' || s[i] == 'a' || s[i] == 'i' || s[i] == 'e' || s[i] == 'u')
                {
                    sum++;
                }
            }
            return sum;
        }
    }
}
