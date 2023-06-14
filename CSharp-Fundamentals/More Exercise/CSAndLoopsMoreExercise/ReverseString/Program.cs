using System;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string drow = "";
            char c;
            for (int i = 1; i <= word.Length; i++)
            {
                c = word[word.Length - i];
                drow += c;
            }
            Console.WriteLine(drow);
        }
    }
}
