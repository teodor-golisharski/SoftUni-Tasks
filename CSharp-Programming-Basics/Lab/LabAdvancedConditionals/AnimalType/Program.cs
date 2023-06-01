using System;

namespace AnimalType
{
    class Program
    {
        static void Main(string[] args)
        {
            string animal = Console.ReadLine();
            string status="";
            switch (animal)
            {
                case "dog":status = "mammal";break;
                case "crocodile": case "tortoise": case "snake": status = "reptile";break;
                default: status = "unknown";break;
            }
            Console.WriteLine(status);
        }
    }
}
