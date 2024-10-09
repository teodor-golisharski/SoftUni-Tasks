using System;
using System.Linq;

namespace CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> startsWithUpper = w => char.IsUpper(w[0]);

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(x => startsWithUpper(x))
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, input));
        }
    }
}
