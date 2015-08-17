using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Tavisca.Templar.UIAutomation.Extensions.Helpers
{
    public partial class DateParser
    {
        public static int ParseLongMonthNameToMonthNumber(string monthName)
        {
            var value = DateTime.ParseExact(monthName, "MMMM", DateTimeFormatInfo.InvariantInfo).Month;
            return value;
        }

        public static int ParseShortMonthNameToMonthNumber(string monthName)
        {
            var value = DateTime.ParseExact(monthName, "MMM", DateTimeFormatInfo.InvariantInfo).Month;
            return value;
        }

        public static string ParseMonthNumberToLongMonthName(string monthNumber)
        {
            var value = DateTime.ParseExact(monthNumber, "MM", DateTimeFormatInfo.InvariantInfo);
            return value.ToLongDateString().Split(',')[1].Split(' ')[1];
        }

        public static string ParseMonthNumberToShortMonthName(string monthNumber)
        {
            var value = DateTime.ParseExact(monthNumber, "MM", DateTimeFormatInfo.InvariantInfo);
            return value.ToLongDateString().Split(',')[1].Split(' ')[1].Substring(0, 3);
        }
    }
}
