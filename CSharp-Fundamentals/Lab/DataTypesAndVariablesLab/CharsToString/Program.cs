using System;

namespace CharsToString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                char c = char.Parse(Console.ReadLine());
                s += c;
            }
            Console.WriteLine(s);
        }
    }
}
