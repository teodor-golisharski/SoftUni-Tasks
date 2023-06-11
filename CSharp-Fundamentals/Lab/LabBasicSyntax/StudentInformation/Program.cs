using System;

namespace StudentInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            double avgGrade = double.Parse(Console.ReadLine());
            Console.WriteLine($"Name: {name}, Age: {age}, Grade: {avgGrade:f2}");
        }
    }
}
