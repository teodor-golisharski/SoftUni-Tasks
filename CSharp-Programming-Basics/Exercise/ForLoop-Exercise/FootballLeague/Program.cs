using System;

namespace FootballLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            double n = int.Parse(Console.ReadLine());
            double aa = 0;
            double bb = 0;
            double vv = 0;
            double gg = 0;
            for (int i = 1; i <= n; i++)
            {
                char sector = char.Parse(Console.ReadLine());
                switch (sector)
                {
                    case 'A':aa++;break;
                    case 'B':bb++;break;
                    case 'V':vv++;break;
                    case 'G':gg++;break;
                }
            }
            Console.WriteLine($"{aa/n*100:f2}%");
            Console.WriteLine($"{bb/n*100:f2}%");
            Console.WriteLine($"{vv/n*100:f2}%");
            Console.WriteLine($"{gg/n*100:f2}%");
            Console.WriteLine($"{n/capacity*100:f2}%");
        }
    }
}
