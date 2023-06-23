using System;

namespace RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Repeater(s,n));
        }
        static string Repeater(string s, int n)
        {
            string result = "";
            for (int i = 0; i < n; i++)
            {
                result += s;
            }
            return result;
        }
    }
}
