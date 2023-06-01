using System;

namespace NumberInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            if(num>=-100&&num<=100)
            {
                if(num!=0)
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
