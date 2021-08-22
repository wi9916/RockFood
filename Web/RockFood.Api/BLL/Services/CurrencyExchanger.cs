using RockFood.Interfaces;
using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;


namespace RockFood.Services
{
    public class CurrencyExchanger: IExchangerable
    {
        private CurrencyRate currency;
        private DateTime date;
        public async Task GetNewCurrencyAsync()
        {
            date = DateTime.Today.AddDays(-1);
            var client = new HttpClient();            
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://api.privatbank.ua/p24api/exchange_rates?json&date="+date.ToString("dd.MM.yyyy"));

            var response = await client.SendAsync(request).ConfigureAwait(false);

            currency = JsonSerializer.Deserialize<CurrencyRate>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions{PropertyNameCaseInsensitive = true}
                );           
        } 
        public async Task<decimal> GetExchangeRateAsync(string currencyName)
        {
            if (date != DateTime.Today.AddDays(-1))
                await GetNewCurrencyAsync();

            var currentCurrency = currency.ExchangeRate.FirstOrDefault(x => x.Currency == currencyName);

            return currentCurrency.SaleRate;
        }
    }
}
