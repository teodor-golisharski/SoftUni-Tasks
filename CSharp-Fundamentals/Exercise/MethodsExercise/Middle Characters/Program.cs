using System;

namespace Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            if (s.Length % 2 == 0)
            {
                Console.WriteLine(Even(s));
            }
            else
            {
                Console.WriteLine(Odd(s));
            }
        }
        static char Odd(string s)
        {
            return s[s.Length / 2];
        }
        static string Even(string s)
        {
            char c = s[s.Length / 2 - 1];
            char cc = s[s.Length / 2];
            string res = "";
            res += c;
            res += cc;
            return res;
        }
    }
}
