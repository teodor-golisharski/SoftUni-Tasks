using System;

namespace AreaOfFigure
{
    class Program
    {
        static void Main(string[] args)
        {
            double area = 0;
            string s = Console.ReadLine();
            if (s == "square")
            {
                double a = double.Parse(Console.ReadLine());
                area = Math.Pow(a, 2);

            }
            else if (s == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                area = a * b;

            }
            else if (s == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                area = Math.PI * Math.Pow(r, 2);

            }
            else if (s == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                area = (a * h) / 2;
            }

            Console.WriteLine($"{area:f3}");
        }
    }
}
