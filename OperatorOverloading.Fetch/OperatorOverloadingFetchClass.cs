using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;

namespace OperatorOverloading.Fetch
{
    public class OperatorOverloadingFetchClass
    {
        public static string OperatorOverloadingFetchFunction()
        {
             //fetching information from http page
       
            //used to build entire input
            StringBuilder strtingBuilder = new StringBuilder();

            // used on each read operation
            byte[] buf = new byte[8000];

            // prepare the web page we will be asking for
            HttpWebRequest request = (HttpWebRequest)
            WebRequest.Create("http://www.apilayer.net/api/live?access_key=d80938d5fce7d926442581f56258688c&format=1");

            // execute the request
            HttpWebResponse response = (HttpWebResponse)
            request.GetResponse();

            // we will read data via the response stream
            Stream resStream = response.GetResponseStream();

            string tempString = null;
            int count = 0;

            do
            {
                // fill the buffer with data
                count = resStream.Read(buf, 0, buf.Length);

                // make sure we read some data
                if (count != 0)
                {
                    // translate from bytes to ASCII text
                    tempString = Encoding.ASCII.GetString(buf, 0, count);

                    // continue building the string
                    strtingBuilder.Append(tempString);
                }
            }
            while (count > 0); // any more data to read?
            String string1  = strtingBuilder.ToString();
            return (string1);
        }
    }
}
