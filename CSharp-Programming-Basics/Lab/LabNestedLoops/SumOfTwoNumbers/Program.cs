using System;

namespace SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int s = int.Parse(Console.ReadLine());
            int f = int.Parse(Console.ReadLine());
            int magic = int.Parse(Console.ReadLine());
            int counter = 0;
            bool check = false;

            for (int i = s; i <= f; i++)
            {
                for (int j = s; j <= f; j++)
                {
                    counter++;
                    if (i + j == magic)
                    {
                        check = true;
                        Console.WriteLine($"Combination N:{counter} ({i} + {j} = {magic})");
                        return;
                    }
                }
            }
            if(check == false)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magic}");
            }
        }
    }
}
