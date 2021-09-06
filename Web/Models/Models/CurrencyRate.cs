using Models.Models;
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
		public List<ExchangeRate> ExchangeRate { get; set; }				
	}	
}
