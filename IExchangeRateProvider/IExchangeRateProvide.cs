using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace IExchangeRateProvide
{
    public interface IExchangeRateProvider
    {
        double GetExchangeRate(string From, string To);
    }
}
