using System;

namespace WeekendOrWorkday
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            string status;
            switch (day)
            {
                case "Monday": status = "Working day"; break;
                case "Tuesday": status = "Working day"; break;
                case "Wednesday": status = "Working day"; break;
                case "Thursday": status = "Working day"; break;
                case "Friday": status = "Working day"; break;
                case "Saturday": status = "Weekend"; break;
                case "Sunday": status = "Weekend"; break;
                default: status = "Error"; break;
            }
            Console.WriteLine(status);
        }
    }
}
