using System;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string input = Console.ReadLine();
            double total = 0;
            int grade = 1;
            int att = 2;
            while (grade <= 12)
            {
                double num = double.Parse(input);
                if (num <= 3.99)
                {
                    att--;
                }
                if (att == 0)
                {
                    Console.WriteLine($"{name} has been excluded at {grade - 1} grade"); break;
                }
                total += num;
                grade++;
                input = Console.ReadLine();
            }
            double avg = total / (grade-1);
            if (att != 0)
            {
                Console.WriteLine($"{name} graduated. Average grade: {avg:f2}");
            }
        }
    }
}
