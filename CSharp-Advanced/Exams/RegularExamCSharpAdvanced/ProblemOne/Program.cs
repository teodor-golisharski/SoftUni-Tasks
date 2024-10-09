using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialCaffeine = 0;
            const int maximumCapacity = 300;

            Stack<int> milligramsOfCaffeine = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> numberOfEnergyDrinks = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            while (milligramsOfCaffeine.Count > 0 && numberOfEnergyDrinks.Count > 0)
            {
                int currentMilligrams = milligramsOfCaffeine.Pop();
                int currentNumberOfEnergyDrinks = numberOfEnergyDrinks.Dequeue();

                int totalCaffeine = currentMilligrams * currentNumberOfEnergyDrinks;

                if (totalCaffeine > maximumCapacity - initialCaffeine)
                {
                    if (initialCaffeine <= 30)
                    {
                        initialCaffeine = 0;
                    }
                    else
                    {
                        initialCaffeine -= 30;
                    }
                    numberOfEnergyDrinks.Enqueue(currentNumberOfEnergyDrinks);
                }
                else if (totalCaffeine <= maximumCapacity - initialCaffeine)
                {
                    initialCaffeine += totalCaffeine;
                }
            }
            if (numberOfEnergyDrinks.Count > 0)
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", numberOfEnergyDrinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }
            Console.WriteLine($"Stamat is going to sleep with {initialCaffeine} mg caffeine.");

        }
    }
}
