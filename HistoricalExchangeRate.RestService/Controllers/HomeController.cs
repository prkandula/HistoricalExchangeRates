using HistoricalExchangeRate.Interfaces;
using HistoricalExchangeRate.Model.Api;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace HistoricalExchangeRate.RestService.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IExchangeRate _exchangeRate;
        public HomeController(IExchangeRate exchangeRate)
        {
            this._exchangeRate = exchangeRate;
        }

        
        [HttpGet]
        [Route("{dates}/{baseCurrency}/{symbols}")]
        public async Task<OutputRate> GetRates([FromQuery] string[] dates, [FromQuery] string baseCurrency, [FromQuery] string symbols)
        {
            var response = await _exchangeRate.GetRate(dates, baseCurrency, symbols);


            return response;
        }
        

    }
}
