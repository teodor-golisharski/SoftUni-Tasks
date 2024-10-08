using System;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string seq = Console.ReadLine();
            while(seq.Contains(word))
            {
                int startIndex = seq.IndexOf(word);
                seq = seq.Remove(startIndex, word.Length);
            }
            Console.WriteLine(seq);
        }
    }
}
