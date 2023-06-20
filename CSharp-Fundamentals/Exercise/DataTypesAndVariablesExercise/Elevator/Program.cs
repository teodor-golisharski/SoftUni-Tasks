using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            int fullcourses = (int)Math.Ceiling((double)people / capacity);
            Console.WriteLine(fullcourses);
        }
    }
}
