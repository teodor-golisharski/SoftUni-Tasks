using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();
            int diff = DateModifier.DateDifference(startDate, endDate);
            Console.WriteLine(diff);
        }
    }
}
