using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IExchangeRateProvide;

namespace OperatorOverloading.Parse
{    
    public class ApiLayerExchangeRateProvider : IExchangeRateProvider
    {
        public double GetExchangeRate(string From, string To)
        {

            //converting to uppercase because API data is in uppercase
            From = From.ToUpper();
            To = To.ToUpper();
            
            //if both currencies are equal
            if (From.Equals(To))
            return (1.0);
            
            //Dictionary to store currency as key and conversion rates as value
            Dictionary<string, double> dictionary = new Dictionary<string, double>();

            //to keep track of number of occurence in a loops
            int track = 0;

            //copying stringBuilder sb to string s to be able to perform string operations
           // string s = OperatorOverloadingFetchClass.OperatorOverloadingFetchFunction();
            string s = File.ReadAllText(@"D:\TrainingRepo\training\ConversionRates.txt");    

            // string s is of form {...{__information___}} 
            string[] words1 = s.Split('{');   //spliting s to get __information__}} 
            string[] words2 = (words1[2]).Split('}');  //further splitting to get __information__

            //now __information__ is of the form  "key1":value1,  "key2":value2,  "key3":value3 
            string[] words3 = (words2[0]).Split(',');  //further splitting to get "key":value
            foreach (string word in words3)
            {
                //replacing '"' by space ' ' and trimming to convert "key":value to key:value
                words3[track] = (word.Replace('"', ' ')).Trim();

                //further splitting to convert key:value to key value 
                string[] words4 = (words3[track]).Split(':');

                //Now adding key and value to dictionary
                dictionary.Add((words4[0]).Substring(0, 6), Convert.ToDouble(words4[1]));
                track++;
            }

            //index1 and index2 will store index of both currencies
            //checkUsd1 and checkUsd2 will store whether they are USD or not
            int index1 = int.MaxValue, index2 = int.MaxValue, checkUsd1 = 0, checkUsd2 = 0;
            double value1 = 0, value2 = 0;
            track = 1;
            foreach (KeyValuePair<string, double> pair in dictionary)
            {

                if ((pair.Key.ToString()).Contains(From)) //checks for From in key
                {

                    if (From.Equals("USD"))
                        checkUsd1 = 1;
                    else
                    {
                        checkUsd1 = 0;
                        value1 = pair.Value;
                    }
                    index1 = track;
                }
                if ((pair.Key.ToString()).Contains(To)) //ckecks for To in key
                {
                    if (To.Equals("USD"))
                        checkUsd2 = 1;
                    else
                    {
                        checkUsd2 = 0;
                        value2 = pair.Value;
                    }
                    index2 = track;
                }
                track++;
            }
           

            //if either index not present then its value wil be intmax 
            try
            {
                if (index1 > dictionary.Count || index2 > dictionary.Count)
                    //Console.WriteLine("Either of the currency not present");
                    throw new ArgumentException("either of the currency not present");
            }
            catch(Exception Object)
            {
                throw Object;
            }


            //if 1st currency is USD
            if (checkUsd1 == 1)
                return(value2);

            //if second currency is USD
            else if (checkUsd2 == 1)
                return(1 / value1);

            //if neither currency is USD
            else if (checkUsd1 == 0 && checkUsd2 == 0)
                return(value2 / value1);
            return (0);
        }
    }
}
