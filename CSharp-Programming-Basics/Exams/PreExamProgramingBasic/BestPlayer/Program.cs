using System;

namespace BestPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int maxgoals = int.MinValue;
            string bestPlayer = "";
            while ((input = Console.ReadLine()) != "END")
            {
                string name = input;
                int goals = int.Parse(Console.ReadLine());
                if (goals > maxgoals)
                {
                    maxgoals = goals;
                    bestPlayer = name;
                }
                if(maxgoals>=10)
                {
                    break;
                }
            }
            Console.WriteLine($"{bestPlayer} is the best player!");
            if (maxgoals >= 3)
            {
                Console.WriteLine($"He has scored {maxgoals} goals and made a hat-trick !!!");
                
            }
            else
            {
                Console.WriteLine($"He has scored {maxgoals} goals.");
            }
        }
    }
}
