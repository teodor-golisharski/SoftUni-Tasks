using System;

namespace SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int spices = 0;
            int counter = 0;
            if (startingYield >= 100)
            {
                while (startingYield >= 100)
                {
                    spices += startingYield - 26;
                    startingYield -= 10;
                    counter++;
                }
                spices -= 26;
                Console.WriteLine(counter);
                Console.WriteLine(spices);
            }
            else
            { 
                Console.WriteLine(counter);
                Console.WriteLine(spices);
            }
        }
    }
}
