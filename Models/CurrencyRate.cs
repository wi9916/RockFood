using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Models
{
    public class CurrencyRate
    {
		[JsonProperty(PropertyName = "exchangeRate")]
		public List<ExchangeRate> exchangeRate { get; set; }				
	}
	public class ExchangeRate
    {
		[JsonProperty(PropertyName = "baseCurrency")]
		public string baseCurrency { get; set; }

		[JsonProperty(PropertyName = "currency")]
		public string currency { get; set; }

        [JsonProperty(PropertyName = "saleRateNB")]
        public decimal saleRateNB { get; set; }

        [JsonProperty(PropertyName = "purchaseRateNB")]
        public decimal purchaseRateNB { get; set; }

        [JsonProperty(PropertyName = "saleRate")]
        public decimal saleRate { get; set; }

        [JsonProperty(PropertyName = "purchaseRate")]
        public decimal purchaseRate { get; set; }
    }
}
