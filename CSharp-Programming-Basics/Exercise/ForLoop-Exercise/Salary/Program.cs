using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());
            double fine = 0;
            for (int i = 1; i <= n; i++)
            {
                string tab = Console.ReadLine();
                switch (tab)
                {
                    case "Facebook":fine += 150;break;
                    case "Instagram":fine += 100;break;
                    case "Reddit":fine += 50;break;
                    default:fine += 0;break;
                }
            }
            if(fine>=salary)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else if(fine<salary)
            {
                Console.WriteLine(Math.Abs(salary-fine));
            }
        }
    }
}
