using System;

namespace TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            double sum = 0;
            double final=0;
            int counter = 0;
            while (input != "Finish")
            {
                string trainer = input;
                for (int i = 1; i <= n; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    sum += grade;
                }
                counter++;
                final += sum;
                Console.WriteLine($"{trainer} - {sum/n:f2}.");
                sum = 0;
                input = Console.ReadLine();
            }
            Console.WriteLine($"Student's final assessment is {final/(n*counter):f2}.");
        }
    }
}
