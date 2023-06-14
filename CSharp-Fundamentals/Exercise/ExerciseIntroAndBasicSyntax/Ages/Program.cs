using System;

namespace Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int year = int.Parse(Console.ReadLine());
            if (year >= 0 && year <= 2)
            {
                Console.WriteLine("baby");
            }
            else if (year >= 3 && year <= 13)
            {
                Console.WriteLine("child");
            }
            else if (year >= 14 && year <= 19)
            {
                Console.WriteLine("teenager");
            }
            else if (year >= 20 && year <= 65)
            {
                Console.WriteLine("adult");
            }
            else if (year >= 66)
            {
                Console.WriteLine("elder");
            }
        }
    }
}
