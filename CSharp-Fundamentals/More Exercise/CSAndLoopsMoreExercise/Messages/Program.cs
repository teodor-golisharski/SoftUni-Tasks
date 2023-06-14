using System;

namespace Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string message = "";
            for (int i = 0; i < n; i++)
            {
                string dig = Console.ReadLine();
                int digitLength = dig.Length;
                int digit = dig[0] - '0';
                int offset = (digit - 2) * 3;
                if (digit == 0)
                {
                    message += (char)(digit + 32);
                    continue;
                }

                if (digit == 8 || digit == 9)
                {
                    offset++;
                }
                int letterIndex = offset + digitLength - 1;
                message += (char)(letterIndex + 97);
            }
            Console.WriteLine(message);
        }

    }
}
