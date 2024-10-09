using System;

namespace CarManufacterer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "Mercedes-Benz";
            car.Model = "E350";
            car.Year = 2014;
            car.FuelQuantity = 70;
            car.FuelConsumption = 0.05;
            car.Drive(1000);
            Console.WriteLine(car.WhoAmI());
        }
    }
}
