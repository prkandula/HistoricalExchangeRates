using HistoricalExchangeRate.Model.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalExchangeRate.Interfaces
{
    public interface IExchangeRate
    {
        Task<OutputRate> GetRate(string[] dates, string baseCurrency, string symbols);
    }
}
