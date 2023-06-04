using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyGoal = double.Parse(Console.ReadLine());
            double moneyOnHand = double.Parse(Console.ReadLine());
            int con = 0;
            int daysCounter = 0;
            while (moneyOnHand < moneyGoal && con < 5)
            {
                string s = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                if (s == "spend")
                {
                    moneyOnHand -= money;
                    if (moneyOnHand < 0) { moneyOnHand = 0; }
                    con++;
                    daysCounter++;
                    continue;
                }
                if (s == "save")
                {
                    moneyOnHand += money;
                    daysCounter++;
                    con = 0;
                    
                }
            }
            if (con == 5)
            {
                Console.WriteLine($"You can't save the money.");
                Console.WriteLine(daysCounter);
            }
            else if(moneyOnHand>=moneyGoal)
            {
                Console.WriteLine($"You saved the money for {daysCounter} days.");
            }
        }
    }
}
