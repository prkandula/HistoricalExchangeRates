using HistoricalExchangeRate.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricalExchangeRate
{
       
    public class ConsoleApp
    {
        private readonly IExchangeRate _exchangeRate;
        public ConsoleApp(IExchangeRate exchangeRate)
        {
            this._exchangeRate = exchangeRate;
        }
        public void Run()
        {
            try
            {
                Console.WriteLine("Please enter a historical dates to get exchange rates");
                string[] dates = Console.ReadLine().Split(' '); ////{ "2020-01-12", "2020-04-13" } ; 
                Console.WriteLine("Please enter a base currency ");
                string baseCurrency = Console.ReadLine();
                Console.WriteLine("Please enter a currency symbol to convert");
                string symbols = Console.ReadLine();
                ////Console.ReadKey();
                var rates = this._exchangeRate.GetRate(dates,baseCurrency,symbols);
                rates.Wait();
                if (rates != null)
                {
                    Console.WriteLine(rates.Result.ToString());
                    Console.ReadLine();
                }

                throw new Exception();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an error processing this request: {ex.Message}");
                Environment.Exit(1);
            }
        }
    }
}