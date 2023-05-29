using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double s = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double sPerM = double.Parse(Console.ReadLine());
            double d = Math.Floor(distance / 15);
            double n = d * 12.5;
            double total = (distance * sPerM) + n;
            
            double sth = Math.Abs(total - s);
            if(s<=total)
            {
                Console.WriteLine($"No, he failed! He was {sth:f2} seconds slower.");
            }
            else if(s>total)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {total:f2} seconds.");
            }
        }
    }
}
