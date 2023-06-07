using System;

namespace Substitute
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            for (int i = k; i <= 8; i++)
            {
                for (int j = 9; j >= l; j--)
                {
                    for (int p = m; p <= 8; p++)
                    {
                        for (int r = 9; r >= n; r--)
                        {
                            if (i % 2 == 0 
                                && j % 2 != 0 
                                && p % 2 == 0 
                                && r % 2 != 0)
                            {
                                if (i == p && j == r)
                                {
                                    Console.WriteLine("Cannot change the same player.");
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine($"{i}{j} - {p}{r}");
                                    counter++;
                                }
                                if (counter >= 6)
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
