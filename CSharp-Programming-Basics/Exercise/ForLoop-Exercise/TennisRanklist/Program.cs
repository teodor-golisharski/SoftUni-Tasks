using System;

namespace TennisRanklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int points = int.Parse(Console.ReadLine());
            double totalPoints = points;
            double numW = 0;
            for (int i = 1; i <= n; i++)
            {
                string stage = Console.ReadLine();
                switch (stage)
                {
                    case "W": totalPoints += 2000; numW++; break;
                    case "F": totalPoints += 1200; break;
                    case "SF": totalPoints += 720; break;
                }

            }
            Console.WriteLine("Final points: " + totalPoints);
            Console.WriteLine($"Average points: {Math.Floor((totalPoints - points) / n)}");
            Console.WriteLine($"{((numW / n) * 100):f2}%");
        }
    }
}
