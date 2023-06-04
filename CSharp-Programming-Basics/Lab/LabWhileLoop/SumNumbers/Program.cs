using System;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            while (num > sum)
            {
                int currentNum = int.Parse(Console.ReadLine()); 
                sum += currentNum;
            }
            Console.WriteLine(sum);
        }

    }
}
