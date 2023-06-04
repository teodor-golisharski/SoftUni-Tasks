using System;

namespace EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            for (int i = n1; i <= n2; i++)
            {
                string current = i.ToString();
                int odds = 0;
                int evens = 0;
                for (int j = 0; j < current.Length; j++)
                {
                    int currentDigit = int.Parse(current[j].ToString());
                    if (j % 2 == 0)
                    {
                        evens += currentDigit;
                    }
                    else
                    {
                        odds += currentDigit;
                    }
                }
                if (odds == evens)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
