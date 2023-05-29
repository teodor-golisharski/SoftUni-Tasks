using System;

namespace GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double filmBudget = double.Parse(Console.ReadLine());
            int stats = int.Parse(Console.ReadLine());
            double clothStats = double.Parse(Console.ReadLine());
            double decor = filmBudget * 0.1;
            double price = stats * clothStats;
            if(stats>150)
            {
                price = price * 0.9;
            }
            price = price + decor;
            double left = Math.Abs(price - filmBudget);
            if(price>filmBudget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {left:f2} leva more.");
            }
            else if(filmBudget>=price)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {left:f2} leva left.");
            }
        }
    }
}
