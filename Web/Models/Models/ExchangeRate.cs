using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class ExchangeRate
    {
        [JsonProperty(PropertyName = "baseCurrency")]
        public string BaseCurrency { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "saleRateNB")]
        public decimal SaleRateNB { get; set; }

        [JsonProperty(PropertyName = "purchaseRateNB")]
        public decimal PurchaseRateNB { get; set; }

        [JsonProperty(PropertyName = "saleRate")]
        public decimal SaleRate { get; set; }

        [JsonProperty(PropertyName = "purchaseRate")]
        public decimal PurchaseRate { get; set; }
    }
}
