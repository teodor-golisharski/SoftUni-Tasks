using System;

namespace AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            int min = Math.Min((int)a, (int)b);
            int max = Math.Max((int)a, (int)b);
            string s = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if((int)s[i] > min && (int)s[i] < max)
                {
                    sum += (int)s[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
