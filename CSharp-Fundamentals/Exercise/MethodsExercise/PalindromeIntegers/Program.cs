using System;

namespace PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                int n = int.Parse(input);
                Console.WriteLine(Checker(n));
                input = Console.ReadLine();
            }
        }
        static bool Checker(int n)
        {
            string s = n.ToString();
            string s1 = "";
            for (int i = s.Length-1; i >= 0 ; i--)
            {
                s1 += s[i];
            }
            if(s==s1)
            {
                return true;
            }
            return false;
        }
        static bool Odd(int n)
        {
            string s = n.ToString();
            string s1 = "";
            string s2 = "";
            if (s.Length % 2 == 0)
            {
                for (int i = 0; i < s.Length / 2 - 1; i++)
                {
                    s1 += s[i];
                }
            }
            else
            {
                for (int i = 0; i < s.Length / 2; i++)
                {
                    s1 += s[i];
                }
            }
            for (int i = s.Length / 2 + 1; i < s.Length; i++)
            {
                s2 += s[i];
            }
            if (s1 == s2)
            {
                return true;
            }
            return false;
        }
    }
}
