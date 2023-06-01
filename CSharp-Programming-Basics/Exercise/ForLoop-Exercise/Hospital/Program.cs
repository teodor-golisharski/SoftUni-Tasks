using System;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int period = int.Parse(Console.ReadLine());
            int sumOfExaminations = 0;
            int nonExamined = 0;
            int doctors = 7;
            for (int i = 1; i <= period; i++)
            {
                int patients = int.Parse(Console.ReadLine());
                if (i % 3 == 0)
                {
                    if (nonExamined > sumOfExaminations)
                    {
                        doctors++;
                    }
                }
                if (patients > doctors)
                {
                    nonExamined += (patients - doctors);
                    sumOfExaminations += doctors;
                }
                else if (doctors >= patients)
                {
                    sumOfExaminations += patients;
                }
            }
            Console.WriteLine($"Treated patients: {sumOfExaminations}.");
            Console.WriteLine($"Untreated patients: {nonExamined}.");

        }
    }
}
