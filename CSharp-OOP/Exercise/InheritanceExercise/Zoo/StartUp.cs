using System;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Bear bear = new Bear("Mitko");
            Animal animal = new Animal("jivotno");

            Console.WriteLine(bear.Name);
            Console.WriteLine(animal.Name);
        }
    }
}