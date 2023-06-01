using System;

namespace Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double academyPoints = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            double totalPoints = 0;
            for (int i = 1; i <= n; i++)
            {
                string juryName = Console.ReadLine();
                double juryPoints = double.Parse(Console.ReadLine());
                totalPoints += (juryName.Length * juryPoints) / 2;
                if (totalPoints + academyPoints >= 1250.5)
                {
                    Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {(totalPoints + academyPoints):f1}!"); break;
                }
                
            }
            if (totalPoints + academyPoints < 1250.5)
                {
                    Console.WriteLine($"Sorry, {actorName} you need {(Math.Abs((totalPoints+academyPoints)-1250.5)):f1} more!");
                }

        }
    }
}
