using System;

namespace Dishwasher
{
    class Program
    {
        static void Main(string[] args)
        {
            int bottles = int.Parse(Console.ReadLine());
            int detergent = bottles * 750;
            int counter = 1;
            int potCounter = 0;
            int plateCounter = 0;
            while (detergent > 0)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                int pots = int.Parse(input);
                if (counter % 3 == 0)
                {
                    detergent -= 15 * pots;
                    potCounter += pots;
                }
                else
                {
                    detergent -= 5 * pots;
                    plateCounter += pots;
                }
                if (detergent > 0)
                {
                    counter++;
                }
                else
                {
                    break;
                }
            }
            if (detergent >= 0)
            {
                Console.WriteLine($"Detergent was enough!");
                Console.WriteLine($"{plateCounter} dishes and {potCounter} pots were washed.");
                Console.WriteLine($"Leftover detergent {Math.Abs(detergent)} ml.");
            }
            else
            {
                Console.WriteLine($"Not enough detergent, {Math.Abs(detergent)} ml. more necessary!");
            }
        }
    }
}
