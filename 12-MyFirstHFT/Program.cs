using _12_MyFirstHFT.Classes;
using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace _12_MyFirstHFT
{
    class Program
    {
        private static decimal pastAsk; 

        static void Main(string[] args)
        {
            Console.WriteLine("Please input your stocks ticker symbol and press Enter");
            // this saves the user input to a string
            string ticker = Console.ReadLine();

            //this is the timer
            var timer = new System.Threading.Timer(e => stock, null, TimeSpan.Zero.TimeSpan.FromSeconds(3));


            using (WebClient webClient = new WebClient())

            {
                Stock stock = new Stock();
                //Says Hello to Yahoo Finance and tells them we aren't that weird 
                webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                // Grabs json info from github and saves it to a string.
                string json = webClient.DownloadString("https://www.enclout.com/api/v1/yahoo_finance/show.json?&auth_token=nZ8Xy5UVnv2Tos6FUKZ8&text=" + ticker);

                //this converts the json info into usable information for us
                var a = JArray.Parse(json);

               //This saves the json information into a string
                stock.symbol = a[0]["symbol"].ToString();
                stock.ask = a[0]["ask"].ToString();
                

                pastAsk = Convert.ToDecimal(stock.ask);

                
                    //Writes info to console
                    Console.WriteLine("The current price of " + ticker + " is " + stock.ask);

                    Console.ReadLine();
                }
            }
        }
    }
}
