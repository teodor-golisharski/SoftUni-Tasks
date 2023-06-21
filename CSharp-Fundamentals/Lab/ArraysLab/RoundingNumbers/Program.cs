using System;
using System.Linq;
namespace RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine().Split().Select(double.Parse).ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                int rounded = (int)Math.Round(arr[i], MidpointRounding.AwayFromZero);
                Console.WriteLine($"{arr[i]} => {rounded}");
            }
        }
    }
}
