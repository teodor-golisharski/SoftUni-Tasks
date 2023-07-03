using System;

namespace CookingMasterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double flour = double.Parse(Console.ReadLine());
            double egg = double.Parse(Console.ReadLine());
            double apron = double.Parse(Console.ReadLine());
            int freePack = 0;
            for (int i = 1; i <= students; i++)
            {
                if (i % 5 == 0)
                {
                    freePack++;
                }
            }
            double receipt = apron * Math.Ceiling(students * 1.2) + egg * 10 * students + flour * (students - freePack);
            if (receipt > budget)
            {
                Console.WriteLine($"{Math.Abs(receipt - budget):f2}$ more needed.");
            }
            else
            {
                Console.WriteLine($"Items purchased for {receipt:f2}$.");
            }
        }
    }
}
