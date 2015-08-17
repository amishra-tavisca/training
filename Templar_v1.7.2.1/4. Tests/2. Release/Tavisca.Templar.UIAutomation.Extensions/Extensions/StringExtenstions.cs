using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tavisca.TravelNxt.UIAutomation.Extensions
{
    public static class StringExtenstions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }

        #region Globalization Extension
        
        public static decimal ToDecimalPrice(this string priceString)
        {
            var currencySymbol = "$";
            string currencyINR = "R" + "s";
            string stringINR = "INR";
            string stringbhat = "฿";
            string stringUSD = "USD";
            var currencyGroupSepearator = ",";
            decimal returnPrice = 0;
            priceString = priceString.Trim().Replace(currencySymbol, "").Replace(currencyGroupSepearator, "").Replace(currencyINR, "").Replace(stringINR, "").Replace(stringbhat, "").Replace(stringUSD, "").Trim();
            //TODO
            //Handle this in CarFilterAndMatrix.
            if (priceString.Contains("(Total Fare)",StringComparison.InvariantCultureIgnoreCase))
            {
                priceString = priceString.Remove(priceString.IndexOf("(Total Fare)", StringComparison.InvariantCultureIgnoreCase)).Trim();
            }            
            returnPrice = decimal.Parse(priceString);
            return returnPrice;
        } 
        
        #endregion
    }
}
