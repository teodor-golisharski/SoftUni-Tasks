using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int goal = 10000;
            int total = 0;
            
            while (total < goal)
            {
                string steps = Console.ReadLine();
                if(steps == "Going home")
                {
                    total += int.Parse(Console.ReadLine());
                    break;
                }
                total += int.Parse(steps);

            }
            int diff = Math.Abs(total - goal);
            if(total>=goal)
            {
                Console.WriteLine($"Goal reached! Good job!"); 
                Console.WriteLine($"{diff} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{diff} more steps to reach goal.");
            }
        }
    }
}
