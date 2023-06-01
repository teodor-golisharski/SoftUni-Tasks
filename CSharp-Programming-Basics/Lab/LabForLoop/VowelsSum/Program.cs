using System;

namespace VowelsSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char letter = s[i];
                switch (letter)
                {
                    case 'a':sum += 1;break;
                    case 'e':sum += 2;break;
                    case 'i':sum += 3;break;
                    case 'o':sum += 4;break;
                    case 'u':sum += 5;break;
                }

            }
            Console.WriteLine(sum);
        }
    }
}
