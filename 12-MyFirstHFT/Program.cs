using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _12_MyFirstHFT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input your stocks ticker symbol and press Enter");

            string ticker = Console.ReadLine();

            using (WebClient webClient = new WebClient())
            {

                //Says Hello to Yahoo Finance and tells them we aren't that weird 
                webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                // Grabs json info from github and saves it to a string.
                string json = webClient.DownloadString("https://www.enclout.com/api/v1/yahoo_finance/show.json?&auth_token=nZ8Xy5UVnv2Tos6FUKZ8&text=" + ticker);

                //this converts the json info into usable information for us
                var a = JArray.Parse(json);







                //This saves the json information into a string
                string symbol = a[0]["symbol"].ToString();
                string ask = a[0]["ask"].ToString();

                

                //Writes info to console
                Console.WriteLine(ask);
                Console.ReadLine();
            }
        }
    }
}
