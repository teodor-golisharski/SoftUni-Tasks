using System;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string pass = Console.ReadLine();
            string entry = Console.ReadLine();
            while(entry != pass)
            {
                entry = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {name}!");
        }
    }
}
