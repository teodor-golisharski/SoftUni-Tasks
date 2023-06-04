using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double cubicFreeSpace = width * length * height;
            while(cubicFreeSpace>0)
            {
                string command = Console.ReadLine();
                if(command == "Done")
                {
                    break;
                }
                int box = int.Parse(command);
                cubicFreeSpace -= box;
            }
            if(cubicFreeSpace>0)
            {
                Console.WriteLine(cubicFreeSpace + " Cubic meters left.");
            }
            else if(cubicFreeSpace<=0)
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(cubicFreeSpace)} Cubic meters more.");
            }
        }
    }
}
