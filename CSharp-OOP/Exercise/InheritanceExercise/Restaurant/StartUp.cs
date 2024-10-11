using System;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Coffee coffee = new Coffee("cafe", 50);
            HotBeverage hotBeverage = new HotBeverage("voda", 12, 400);

            Fish sharan = new Fish("iotko", 45);
            Tea tea = new Tea("chaiche", 12, 150);
            Beverage beverage = new Beverage("cola", 33, 250);
        }
    }
}