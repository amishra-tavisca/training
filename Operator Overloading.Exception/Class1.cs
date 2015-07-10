using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace OperatorOverloading.exception
{

    [Serializable]
    public class CurrencyNotMatch : Exception
    {
        public string message { get { return base.Message; } } 
        public CurrencyNotMatch()
            : base()
        {

        }

        public CurrencyNotMatch(string message)
            : base(message)
        {
        }

        public CurrencyNotMatch(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
