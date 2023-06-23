using System;

namespace CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            Range(a, b);
        }
        static void Range(char a, char b)
        {
            int start = Math.Min(a, b);
            int end = Math.Max(a, b);
            for (int i = start + 1; i < end; i++)
            {
                Console.Write((char)i + " ");
            }

        }
    }
}
