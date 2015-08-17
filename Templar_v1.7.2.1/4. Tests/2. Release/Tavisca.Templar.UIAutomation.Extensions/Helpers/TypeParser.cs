using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tavisca.Templar.UIAutomation.Extensions.Helpers
{
    public static class TypeParser
    {
        public static bool ToBool(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            if (value.Equals("Y", StringComparison.InvariantCultureIgnoreCase) || value.Equals("YES", StringComparison.InvariantCultureIgnoreCase) || value.Equals("TRUE", StringComparison.InvariantCultureIgnoreCase))
                return true;
            else
                return false;
        }

        public static decimal ToDecimal(this string val)
        {
            if (string.IsNullOrEmpty(val))
                return 0M;
            else
            {
                decimal retVal = 0;
                decimal.TryParse(val, out retVal);
                return retVal;
            }
        }

        public static int ToInt32(this string val)
        {
            if (string.IsNullOrEmpty(val))
                return 0;
            else return int.Parse(val);     
        }

        public static List<string> ToList(this string val, string seperator)
        {
            if (string.IsNullOrEmpty(val))
                return new List<string>();
            else
            {
                return val.Split(new string[] { seperator }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }
    }
}

