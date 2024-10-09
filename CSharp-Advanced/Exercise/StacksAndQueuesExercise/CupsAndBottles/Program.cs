using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            int wastedWater = 0;
            int reduction = 0;
            int currentCup = 0;
            while (cups.Count > 0 && bottles.Count > 0)
            {
                int currentBottle = bottles.Peek();
                
                if(reduction > 0)
                {
                    currentCup -= reduction;
                    reduction = 0;
                }
                else
                {
                    currentCup = cups.Peek();
                }
                if(currentBottle >= currentCup)
                {
                    wastedWater += (currentBottle - currentCup);
                    cups.Dequeue();
                    bottles.Pop();
                }
                else
                {
                    reduction = currentBottle;
                    bottles.Pop();
                }
            }
            if(cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else if(bottles.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
