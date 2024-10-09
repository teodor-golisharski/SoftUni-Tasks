using System;

namespace BoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            Box<double> box = new Box<double>();
            
            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                box.Data.Add(input);
            }
            double element = double.Parse(Console.ReadLine());
            Console.WriteLine(box.Count(element)); 
        }
    }
}
