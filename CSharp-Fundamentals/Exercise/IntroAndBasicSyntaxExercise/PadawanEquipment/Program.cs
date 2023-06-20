using System;

namespace PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());
            double lightsaberNum = Math.Ceiling(students * 1.1);
            double n = students - students / 6;
            double beltsNum = Math.Floor(n);
            double total = lightsaberNum * lightsaberPrice + robePrice * students + beltPrice * beltsNum;
            if(total<=balance)
            {
                Console.WriteLine($"The money is enough - it would cost {total:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {total-balance:f2}lv more.");
            }
        }
    }
}
