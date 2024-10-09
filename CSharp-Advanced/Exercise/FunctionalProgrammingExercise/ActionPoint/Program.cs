using System;
using System.Linq;

namespace ActionPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = (x) => Console.WriteLine(string.Join(Environment.NewLine, x));
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            print(names);
        }
    }
}
