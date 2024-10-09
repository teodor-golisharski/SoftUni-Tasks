using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        public static int DateDifference(string startDate, string endDate)
        {
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);
            TimeSpan difference = start - end;
            return Math.Abs(difference.Days);
        }
    }
}
