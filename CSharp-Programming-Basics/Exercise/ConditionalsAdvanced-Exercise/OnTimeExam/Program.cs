using System;

namespace OnTimeExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourExam = int.Parse(Console.ReadLine());
            int minExam = int.Parse(Console.ReadLine());
            int hourArrival = int.Parse(Console.ReadLine());
            int minArrival = int.Parse(Console.ReadLine());
            int exam = hourExam * 60 + minExam;
            int arrival = hourArrival * 60 + minArrival;
            int dif = Math.Abs(exam - arrival);
            
            if (arrival > exam)
            {
                Console.WriteLine("Late");
                if (dif >= 60)
                {
                    if (dif % 60 < 10)
                    {
                        Console.WriteLine($"{dif / 60}:0{dif % 60} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine($"{dif / 60}:{dif % 60} hours after the start");
                    }
                }
                else
                {
                    Console.WriteLine($"{dif} minutes after the start");
                }
            }
            else if (arrival == exam)
            {
                Console.WriteLine("On time");
            }
            else if (arrival < exam && dif <= 30)
            {
                Console.WriteLine("On time");
                Console.WriteLine($"{dif} minutes before the start");
            }
            else if (arrival < exam && dif > 30)
            {
                Console.WriteLine("Early");
                if (dif >= 60)
                {
                    if (dif % 60 < 10)
                    {
                        Console.WriteLine($"{dif / 60}:0{dif % 60} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{dif / 60}:{dif % 60} hours before the start");
                    }
                }
                else
                {
                    Console.WriteLine($"{dif} minutes before the start");
                }
            }
        }
    }
}
