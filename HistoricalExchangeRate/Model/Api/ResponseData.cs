using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricalExchangeRate.Model.Api
{
    public class ResponseData
    {
        [JsonProperty("motd")]
        public Motd motd { get; set; }

        [JsonProperty("success")]
        public bool success { get; set; }

        [JsonProperty("historical")]
        public bool historical { get; set; }

        [JsonProperty("base")]
        public string baseCurrency { get; set; }

        [JsonProperty("date")]
        public string date { get; set; }

        [JsonProperty("rates")]
        public IDictionary<string, double> rates { get; set; }

    }
    public class Motd
    {
        public string msg { get; set; }
        public string url { get; set; }
    }


}
