using System;

namespace Time_15
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            
            if (m + 15 >= 60)
            {
                h += 1;
                m = 15 - (60 - m);
            }
            else if (m + 15 < 60)
            {
                
                m += 15;
            }
            if (h > 23) h = 0;
            if (m < 10)
            {
                Console.WriteLine($"{h}:0{m}");
            }
            else
            {
                Console.WriteLine($"{h}:{m}");
            }
        }
    }
}
