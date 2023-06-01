using System;

namespace Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int cargos = int.Parse(Console.ReadLine());
            int price = 0;
            double sum = 0;
            int numOfBus = 0;
            double numOfTruck = 0;
            double numOfTrain = 0;
            double totalweight = 0;
            for (int i = 1; i <= cargos; i++)
            {
                int weight = int.Parse(Console.ReadLine());
                if(weight<=3)
                {
                    price = 200 * weight;
                    numOfBus += weight;
                }
                else if(weight>=4&&weight<=11)
                {
                    price = 175 * weight;
                    numOfTruck += weight;
                }
                else if(weight>=12)
                {
                    price = 120 * weight;
                    numOfTrain += weight;
                }
                sum += price;
            }
            totalweight = numOfBus + numOfTrain + numOfTruck;
            Console.WriteLine($"{(sum/totalweight):f2}");
            Console.WriteLine($"{((numOfBus/totalweight)*100):f2}%");
            Console.WriteLine($"{((numOfTruck/totalweight)*100):f2}%");
            Console.WriteLine($"{((numOfTrain/totalweight)*100):f2}%");

        }
    }
}
