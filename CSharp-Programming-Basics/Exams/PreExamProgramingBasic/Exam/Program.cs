using System;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double stat1 = 0;
            double stat2 = 0;
            double stat3 = 0;
            double stat4 = 0;
            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                sum += grade;
                if (grade >= 5)
                {
                    stat1++;
                }
                else if (grade >= 4 && grade <= 4.99)
                {
                    stat2++;
                }
                else if (grade >= 3 && grade <= 3.99)
                {
                    stat3++;
                }
                else if (grade < 3)
                {
                    stat4++;
                }
            }
            double avg = sum / (double)n;
            Console.WriteLine($"Top students: {stat1 / n * 100:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {stat2 / n * 100:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {stat3 / n * 100:f2}%");
            Console.WriteLine($"Fail: {stat4 / n * 100:f2}%");
            Console.WriteLine($"Average: {avg:f2}");
        }
    }
}
