using System;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double top = 0;
            double b45 = 0;
            double b34 = 0;
            double fail = 0;
            double avg = 0;
            for (int i = 1; i <= n; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 5)
                {
                    top++;
                }
                else if (grade < 5 && grade >= 4)
                {
                    b45++;
                }
                else if (grade < 4 && grade >= 3)
                {
                    b34++;
                }
                else if (grade < 3)
                {
                    fail++;
                }
                avg += grade;
            }
            Console.WriteLine($"Top students: {(top / n * 100):f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {(b45 / n * 100):f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {(b34 / n * 100):f2}%");
            Console.WriteLine($"Fail: {(fail / n * 100):f2}%");
            Console.WriteLine($"Average: {avg / n:f2}");
        }
    }
}
