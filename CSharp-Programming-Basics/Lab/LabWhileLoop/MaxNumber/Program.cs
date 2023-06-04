using System;

namespace MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int max = int.MinValue;
            while (input != "Stop")
            {
                int num = int.Parse(input);
                if (num > max)
                {
                    max = num;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(max);
        }
    }
}
