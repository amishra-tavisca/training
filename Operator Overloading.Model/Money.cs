﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using OperatorOverloading.exception;
using OperatorOverloading.Parse;

namespace OperatorOverloading.Model
{

    
   public class Money
    {
        private string _currency;
        public double Amount
        {
            get;
            set;
        }
        public string Currency
        {
            set
            {
                if (string.IsNullOrEmpty(value) || (value).Length != 3)
                {
                    throw new Exception("Invalid Currency.");
                }
               _currency = value;
            }
            get
            {
                
               return _currency;
            }
        }
        public static Money operator +(Money money1, Money money2) //this is operator overloaded function
        {
            if (money1 == null || money2 == null)
            {
                 throw new ArgumentException("Either of the argument is null.");
            }
            Money money3 = new Money();

            if (string.Equals(money1.Currency, money2.Currency, StringComparison.OrdinalIgnoreCase)) //here we r checking whether the currencies of both money is same or not.. if not throw InvalidCurrencyException exception 
            {
                money3.Amount = money1.Amount + money2.Amount;
                if(double.IsInfinity(money3.Amount))// here we r checking whether range of double is exceeded or not....if yes then throw out of range exception
                {
                    throw new OverflowException();
                }
                money3.Currency = money1.Currency;
            }
            else
            {
                throw new OperatorOverloading.exception.CurrencyNotMatch();
            }
            return money3;
        }

        public double convert(string To)
        {
            while (true)// to check currency2 is valid or not
            {
                if (string.IsNullOrEmpty(To) || (To).Length != 3)
                {
                    Console.WriteLine("enter correct currency");
                    To = Console.ReadLine();
                    continue;
                }
                break;
            }
            var object1 = new OperatorOverloadingParseClass();
            return (object1.GetConversionRate(Currency, To));
        }



        public override  string ToString()
        {
            StringBuilder display=new StringBuilder();
            display.Append("Amount1: "+this.Amount+"  Currency1: "+ this.Currency);

            return display.ToString();  
        }

    }       
}