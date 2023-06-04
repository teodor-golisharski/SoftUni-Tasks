using System;

namespace ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            int poorMarks = int.Parse(Console.ReadLine());


            double total = 0;
            int counter = 0;
            int numOfFails = 0;
            string lastProblem = "";
            bool status = true;
            while (numOfFails < poorMarks)
            {
                string mathProblem = Console.ReadLine();
                if (mathProblem == "Enough")
                {
                    status = false;
                    break;
                }
                int mark = int.Parse(Console.ReadLine());
                if (mark <= 4)
                {
                    numOfFails++;
                }
                total += mark;
                counter++;
                lastProblem = mathProblem;
            }
            double average = total / counter;
            if (status == false)
            {
                Console.WriteLine($"Average score: {average:f2}");
                Console.WriteLine($"Number of problems: {counter}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
            else
            {
                Console.WriteLine($"You need a break, {poorMarks} poor grades.");
            }
        }
    }
}
