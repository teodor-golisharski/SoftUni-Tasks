using System;

namespace First_Steps_in_Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());

            double space = (length * width * height)*0.001;
            
            double freeSpace = space * (1 - (percentage / 100));
            Console.WriteLine(freeSpace);
        }
    }
}
