using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricalExchangeRate.Model.Api
{
    public class ExchangeRatesOnDates
    {
        public string Date { get; set; }
        public string Currency { get; set; }
        public double Rate { get; set; }
    }
}
