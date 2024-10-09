using System;
using System.Collections.Generic;

namespace PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = new List<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

            Func<List<string>, int, List<string>> func = (names, n) =>
            {
                for (int i = 0; i < names.Count; i++)
                {
                    if (names[i].Length > n)
                    {
                        names.Remove(names[i]);
                        i--;
                    }
                }
                return names;
            };

            func(names, n);
            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
