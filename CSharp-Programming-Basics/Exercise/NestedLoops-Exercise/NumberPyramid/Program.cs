using System;

namespace NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int current = 1;
            bool b = false;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (current > n)
                    {
                        b = true;
                        break;
                    }
                    Console.Write(current + " ");
                    current++;
                }
                if(b)
                {
                    break;
                }
                Console.WriteLine();

            }
        }
    }
}
