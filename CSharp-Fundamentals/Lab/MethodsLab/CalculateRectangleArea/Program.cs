using System;

namespace CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            Console.WriteLine(RectArea(w, h)); ;
        }
        static double RectArea(double w, double h)
        {
            return w * h;
        }
    }
}
