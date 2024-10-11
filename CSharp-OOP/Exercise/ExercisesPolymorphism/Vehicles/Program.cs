using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] truckInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] busInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            Vehicle car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]), double.Parse(carInput[3]));
            Vehicle truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]), double.Parse(truckInput[3]));
            Vehicle bus = new Bus(double.Parse(busInput[1]), double.Parse(busInput[2]), double.Parse(busInput[3]));
            
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                
                string command = cmdArgs[0];
                string vehicle = cmdArgs[1];
                double value = double.Parse(cmdArgs[2]);

                try
                {

                    if (command == "Drive")
                    {
                        if (vehicle == "Car")
                        {
                            car.Drive(value);
                        }
                        else if (vehicle == "Truck")
                        {
                            truck.Drive(value);
                        }
                        else
                        {
                            bus.Drive(value);
                        }
                    }
                    else if (command == "Refuel")
                    {
                        if (vehicle == "Car")
                        {
                            car.Refuel(value);
                        }
                        else if (vehicle == "Truck")
                        {
                            truck.Refuel(value);
                        }
                        else
                        {
                            bus.Refuel(value);
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        Bus bus1 = (Bus)bus;
                        bus1.DriveEmpty(value);
                        bus = bus1;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
