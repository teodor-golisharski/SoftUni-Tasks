using System;

namespace WorkingHours
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();
            string status = "";
            if (hours >= 10 && hours<= 18)
            {
                switch (day)
                {
                    case "Monday": status = "open";break;
                    case "Tuesday": status = "open";break;
                    case "Wednesday": status = "open";break;
                    case "Thursday": status = "open";break;
                    case "Friday": status = "open";break;
                    case "Saturday": status = "open";break;
                    case "Sunday": status = "closed"; break;
                }
            }
            else if(hours < 10 || hours > 18)
            {
                switch (day)
                {
                    case "Monday": status = "closed"; break;
                    case "Tuesday": status = "closed"; break;
                    case "Wednesday": status = "closed"; break;
                    case "Thursday": status = "closed"; break;
                    case "Friday": status = "closed"; break;
                    case "Saturday": status = "closed"; break;
                    case "Sunday": status = "closed";break;
                }
            }
            Console.WriteLine(status);
           
        }
    }
}
