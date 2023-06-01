using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            int column = int.Parse(Console.ReadLine());
            double price = 0;
            switch(type)
            {
                case "Premiere": price = 12;break;
                case "Normal":price = 7.5;break;
                case "Discount":price = 5;break;
            }
            double profit = row * column * price;
            Console.WriteLine($"{profit:f2} leva");
        }
    }
}
