using System;

namespace CourierExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            double package = double.Parse(Console.ReadLine());
            string serviceType = Console.ReadLine();
            int distance = int.Parse(Console.ReadLine());
            double delivery = 0;
            if (package < 1)
            {
                delivery = 0.03;
            }
            else if (package >= 1 && package < 10)
            {
                delivery = 0.05;
            }
            else if (package >= 10 && package < 40)
            {
                delivery = 0.10;
            }
            else if (package >= 40 && package < 90)
            {
                delivery = 0.15;
            }
            else if (package >= 90 && package < 150)
            {
                delivery = 0.2;
            }
            if (serviceType == "standard")
            {
                Console.WriteLine($"The delivery of your shipment with weight of {package:f3} kg. would cost {delivery * distance:f2} lv.");
            }
            else if(serviceType == "express")
            {
                double delivery1 = distance * delivery;
                double markup = 0;
                if (package < 1)
                {
                    markup = 0.8;
                }
                else if (package >= 1 && package < 10)
                {
                    markup = 0.4;
                }
                else if (package >= 10 && package < 40)
                {
                    markup = 0.05;
                }
                else if (package >= 40 && package < 90)
                {
                    markup = 0.02;
                }
                else if (package >= 90 && package < 150)
                {
                    markup = 0.01;
                }
                double result1 = (markup * delivery * distance * package) + delivery1;
                Console.WriteLine($"The delivery of your shipment with weight of {package:f3} kg. would cost {result1:f2} lv.");
            }
        }
    }
}
