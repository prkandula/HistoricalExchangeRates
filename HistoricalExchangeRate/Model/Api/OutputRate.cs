using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricalExchangeRate.Model.Api
{
    public class OutputRate
    {
        public double MinExchangeRate { get; set; }
        public double MaxExchangeRate { get; set; }
        public double AvgExchangeRate { get; set; }
        public string MaxExchDate { get; set; }
        public string MinExchDate { get; set; }
        public override string ToString()
        {
            var output = new List<string>
            {
                $"----------------OUTPUT----------------",
                $"A min rate of { this.MinExchangeRate} on { this.MinExchDate} ",
                $"A max rate of {this.MaxExchangeRate} on {this.MaxExchDate}",
                $"An average rate of {this.AvgExchangeRate}"
            };
            return string.Join($"{(char)10}{(char)10}", output); // 10 = carriage return, 9 = tab
        }
    }
}
