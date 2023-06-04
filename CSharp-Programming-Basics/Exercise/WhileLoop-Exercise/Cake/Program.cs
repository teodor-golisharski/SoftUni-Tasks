using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int total = x * y;
            while (total > 0)
            {
                string pieces = Console.ReadLine();
                if (pieces == "STOP")
                {
                    break;
                }
                total -= int.Parse(pieces);

            }
            if (total >= 0)
            {
                Console.WriteLine(total + " pieces are left.");
            }
            else if(total<0)
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(total)} pieces more.");
            }
        }
    }
}
