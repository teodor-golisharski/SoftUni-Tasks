using System;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string result = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                int ascii = (int)s[i] + 3;
                result += (char)ascii;
            }
            Console.WriteLine(result);
        }
    }
}
