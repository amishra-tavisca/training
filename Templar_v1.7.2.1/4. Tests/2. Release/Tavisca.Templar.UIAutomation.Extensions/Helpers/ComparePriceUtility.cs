using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Tavisca.Templar.UIAutomation.Extensions.Helpers
{
   public class ComparePriceUtility
    {
       public static bool IsPriceDifferenceAcceptable(decimal price1,decimal price2)
       {
           var difference =Math.Abs(price1 - price2);
           var absoluteValueOfAllowedDifference =decimal.Parse(ConfigurationManager.AppSettings["AllowedPriceDiffAbsoluteValue"]);
           return difference <= Math.Abs(absoluteValueOfAllowedDifference);
       }

       public static bool IsPriceDifferenceAcceptable(decimal price1, decimal price2,decimal allowedPriceDiff)
       {
           var difference = Math.Abs(price1 - price2);
           return difference <= Math.Abs(allowedPriceDiff);
       }
    }
}
