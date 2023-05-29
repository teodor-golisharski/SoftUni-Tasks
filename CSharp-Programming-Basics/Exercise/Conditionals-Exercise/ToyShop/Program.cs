using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double excursionPrice = double.Parse(Console.ReadLine());
            int nPuzzels = int.Parse(Console.ReadLine());
            int nDolls = int.Parse(Console.ReadLine());
            int nTeddyBears = int.Parse(Console.ReadLine());
            int nMinions = int.Parse(Console.ReadLine());
            int nTrucks = int.Parse(Console.ReadLine());
            double sum = nPuzzels * 2.6 + nDolls * 3 + nTeddyBears * 4.1 + nMinions * 8.2 + nTrucks * 2;
            if ((nPuzzels+nDolls+nTeddyBears+nMinions+nTrucks) >= 50) 
            { 
                sum = sum * 0.75; 
            }
            sum = sum - sum * 0.1;
            double left = Math.Abs(excursionPrice - sum);
            if(excursionPrice>sum)
            {
                Console.WriteLine($"Not enough money! {left:f2} lv needed.");
            }
            else if(sum>=excursionPrice)
            {
                Console.WriteLine($"Yes! {left:f2} lv left.");
            }
        }
    }
}
