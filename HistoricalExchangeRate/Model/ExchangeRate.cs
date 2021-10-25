using Azure;
using HistoricalExchangeRate.Interfaces;
using HistoricalExchangeRate.Model.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalExchangeRate.Model
{
    public class ExchangeRate : IExchangeRate
    {
        public async Task<OutputRate> GetRate(string[] dates, string baseCurrency, string symbols)
        {
            //API call to get the rates
            List<ResponseData> responseData = new List<ResponseData>();
            for (int i = 0; i < dates.Length; i++)
            {
                string url = "https://api.exchangerate.host" + $"/{dates[i]}?base={baseCurrency}&symbols={symbols}";
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode == true)
                {
                    string res = await response.Content.ReadAsStringAsync();
                    var content = JsonConvert.DeserializeObject<ResponseData>(res);
                    responseData.Add(content);
                }
            }
            //assgin the response Currency, rates and dates
            List<ExchangeRatesOnDates> exchangeRatesOnDates = new List<ExchangeRatesOnDates>();
            foreach (var response in responseData)
            {
               exchangeRatesOnDates.Add(new ExchangeRatesOnDates 
               { 
                 Date = response.date, 
                 Currency = response.rates.Keys.SingleOrDefault().ToString(), 
                 Rate = Convert.ToDouble(response.rates.Values.SingleOrDefault()) 
               });
            }
            double[] rates = exchangeRatesOnDates.Select(x => x.Rate).ToArray();
            //Getting Rates on Dates
            double addRates = 0;
            foreach (var rate in rates)
            {
                addRates += rate;
            }
            double maxRate = rates.Max();
            double minRate = rates.Min();
            double avgRate = addRates / rates.Count();
            string maxdate = exchangeRatesOnDates.Where(c => c.Rate == maxRate).Select(d => d.Date).FirstOrDefault();
            string mindate = exchangeRatesOnDates.Where(c => c.Rate == minRate).Select(d => d.Date).FirstOrDefault();
            return new OutputRate
            {
                MinExchangeRate = minRate,
                MinExchDate = mindate,
                MaxExchangeRate = maxRate,
                MaxExchDate = maxdate,
                AvgExchangeRate = avgRate
            };            
        }
    }
}
