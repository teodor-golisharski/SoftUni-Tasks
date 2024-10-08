using System;

namespace LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double total = 0;
            foreach (var item in input)
            {
                char first = item[0];
                char last = item[item.Length - 1];
                double number = double.Parse(item.Substring(1, item.Length - 2));
                if(char.IsUpper(first))
                {
                    number /= ((int)first - 64);
                }
                else if(char.IsLower(first))
                {
                    number *= ((int)first - 96);
                }
                if(char.IsUpper(last))
                {
                    number -= ((int)last - 64);
                }
                else if(char.IsLower(last))
                {
                    number += ((int)last - 96);
                }
                total += number;
            }
            Console.WriteLine($"{total:f2}");
        }
    }
}
