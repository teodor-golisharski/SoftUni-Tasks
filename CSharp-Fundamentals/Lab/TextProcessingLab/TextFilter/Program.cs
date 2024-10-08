using System;
using System.Linq;

namespace TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();
            foreach (var item in bannedWords)
            {
                string replacement = string.Empty;
                for (int i = 0; i < item.Length; i++)
                {
                    replacement += "*";
                }
                if(text.Contains(item))
                {
                    text = text.Replace(item, replacement);
                }
            }
            Console.WriteLine(text);
        }
    }
}
