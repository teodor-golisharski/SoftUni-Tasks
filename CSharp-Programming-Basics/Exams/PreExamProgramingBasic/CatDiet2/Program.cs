using System;

namespace CatDiet2
{
    class Program
    {
        static void Main(string[] args)
        {
            double pFats = int.Parse(Console.ReadLine());
            double pProteins = int.Parse(Console.ReadLine());
            double pCarbos = int.Parse(Console.ReadLine());
            int calories = int.Parse(Console.ReadLine());
            int pWater = int.Parse(Console.ReadLine());
            double fats = (calories * (pFats / 100)) / 9;
            double proteins = (calories * (pProteins / 100)) / 4;
            double carbos = (calories * (pCarbos / 100)) / 4;
            double calsPerGram = calories / (fats + proteins + carbos);
            double result = (calsPerGram * (100 - pWater)) / 100;
            Console.WriteLine($"{result:f4}");
        }
    }
}

