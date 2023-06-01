using System;

namespace CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double laundryPrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());
            int totalToys = 0;
            double money = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    money = money + (i / 2) * 10;
                    
                }
                else
                {
                    totalToys++;
                }
            }
            double savings = totalToys * toyPrice + money - (n/2*1);
            if(savings>=laundryPrice)
            {
                Console.WriteLine($"Yes! {(Math.Abs(savings-laundryPrice)):f2}");
            }
            else if(savings<laundryPrice)
            {
                Console.WriteLine($"No! {(Math.Abs(savings - laundryPrice)):f2}");
            }
        }
    }
}
