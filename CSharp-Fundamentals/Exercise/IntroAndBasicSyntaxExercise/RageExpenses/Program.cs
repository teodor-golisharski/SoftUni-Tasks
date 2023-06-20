using System;

namespace RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lost = int.Parse(Console.ReadLine());
            double headset = double.Parse(Console.ReadLine());
            double mouse = double.Parse(Console.ReadLine());
            double keyboard = double.Parse(Console.ReadLine());
            double display = double.Parse(Console.ReadLine());
            int nh=0, nm=0, nk=0, nd=0;
            int count = 0;
            for (int i = 1; i <= lost; i++)
            {
                if(i%2==0)
                {
                    nh++;
                    if(i%3==0)
                    {
                        nm++;
                        nk++;
                        count++;
                        if(count%2==0)
                        {
                            nd++;
                        }
                    }
                }
                else if(i%3==0)
                {
                    nm++;
                }
            }
            double result = nh * headset + nm * mouse + nk * keyboard + nd * display;
            Console.WriteLine($"Rage expenses: {result:f2} lv.");
        }
    }
}
