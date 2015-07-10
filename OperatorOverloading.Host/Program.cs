using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OperatorOverloading.Model;
using System.Xml.Serialization;
using System.IO;
using OperatorOverloading.Parse;

namespace OperatorOverloading.Host
{

    class OperatorOverloading
    {
        static void Main(string[] args)
        {
            Money money1 = new Money();
            Money money2 = new Money();
            Money money3 = new Money();
            var object1 = new OperatorOverloadingParseClass();
            Console.WriteLine("For OBJECT 1 :\n");
            while (true)// condition to check currency is not empty
            {
                Console.WriteLine("Enter Currency.");
                try
                {
                    money1.Currency = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
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

            Console.WriteLine();
            Console.WriteLine("For OBJECT2 :\n");

            while (true)// to check currency is valid or not
            {
                Console.WriteLine("Enter Currency.");
                try
                {
                    money2.Currency = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                break;
            }


            while (true) //keep on taking the input unless you enter valid amount.
            {
                Console.WriteLine("Enter amount ");

                string input = Console.ReadLine();
                double temp = 0.0;
                if (double.TryParse(input, out temp))
                {
                    money2.Amount = temp;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Amount, Enter again: ");
                    continue;
                }

            }

            try
            {
                money3 = money1 + money2;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }

            Console.WriteLine();
            Console.WriteLine(money1);
            Console.WriteLine(money2);
            Console.WriteLine("After Addition Object 3:");
            Console.WriteLine(money3);

            string from="",to="";


            //converting from any currency to any other currency
            Console.WriteLine("for conversion from any currency to any other currency ");
            Console.WriteLine("enter 1st currency");
             while (true)// to check currency is valid or not
            {
                from=Console.ReadLine();
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
                 Console.WriteLine("1 {0} = {1} {1}", from, object1.GetConversionRate(from, to), to);

                 //for converting from a money object 
                 Console.WriteLine("conversion rate for money1 currency to say INR = {0}", money1.convert("INR"));
             }
             catch (Exception exceptionObject)
             {
                 Console.WriteLine("EXCEPTION : " + exceptionObject.Message);
             }
                Console.ReadKey();
        }
    }

}
