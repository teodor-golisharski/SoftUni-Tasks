using System;
using System.Linq;

namespace KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, string> func = x => $"Sir {x}";
            string[] names = Console.ReadLine()
                .Split()
                .Select(func)
                .ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
