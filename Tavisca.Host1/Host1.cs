using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OperatorOverloading.Model;
using OperatorOverloading.Parse;

namespace Tavisca.Host1
{
    class Host1
    {
        static void Main(string[] args)
        {
            Money money1 = new Money();
            var object1 = new ApiLayerExchangeRateProvider();
            string from = "", to = "";


            //converting from any currency to any other currency
            Console.WriteLine("for conversion from any currency to any other currency ");
            Console.WriteLine("enter 1st currency");
            while (true)// to check currency is valid or not
            {
                from = Console.ReadLine();
                if (string.IsNullOrEmpty(from) || (from).Length != 3)
                {
                    Console.WriteLine("enter valid Currency");
                    continue;
                }
                break;
            }
            Console.WriteLine("enter 2nd currency");
            while (true)// to check currency is valid or not
            {
                to = Console.ReadLine();
                if (string.IsNullOrEmpty(to) || (to).Length != 3)
                {
                    Console.WriteLine("enter valid Currency");
                    continue;
                }
                break;
            }
            try
            {
                Console.WriteLine("1 {0} = {1} {2}", from, object1.GetExchangeRate(from, to), to);
            }

            catch (Exception exceptionObject)
            {
                Console.WriteLine("EXCEPTION : " + exceptionObject.Message);
            }

            Console.WriteLine("For Money Object :\n");
            while (true)// condition to check currency is not empty
            {
                Console.WriteLine("Enter Currency.");
                try
                {
                    money1.Currency = Console.ReadLine();
                }
                catch (Exception exception1)
                {
                    Console.WriteLine(exception1.Message);
                    continue;
                }
                break;
            }

            while (true)  // keep on taking the input unless you enter valid amount.
            {
                Console.WriteLine("Enter amount ");
                string input = Console.ReadLine();
                double temp = 0.0;
                if (double.TryParse(input, out temp))
                {
                    money1.Amount = temp;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Amount, Enter again: ");
                    continue;
                }
            }
            while (true)// condition to check currency is not empty
            {
                Console.WriteLine("Enter Currency you want to convert it to ");
                try
                {
                    to = Console.ReadLine();
                }
                catch (Exception exception2)
                {
                    Console.WriteLine(exception2.Message);
                    continue;
                }
                break;
            }

            try
            {
                Console.WriteLine("{0}  {1}  =  {2}  {3}",money1.Amount,money1.Currency, money1.convert(to),to);
            }

            catch (Exception exceptionObject)
            {
                Console.WriteLine("EXCEPTION : " + exceptionObject.Message);
            }
        }
    }
}
