using System;

namespace ReadText
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            while (s != "Stop")
            {
                Console.WriteLine(s);
                s = Console.ReadLine();
            }
        }
    }
}
