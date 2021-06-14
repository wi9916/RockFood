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
        private CurrencyRate Currency { get; set; }
        private string Date{ get; set; }
        public async Task GetNewCurrencyAsync()
        {
            Date = DateTime.Today.AddDays(-1).ToString("DD-MM-yyyy");
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://api.privatbank.ua/p24api/exchange_rates?json&date=01.12.2019?currency=CAD");

            var response = await client.SendAsync(request).ConfigureAwait(false);

            Currency = JsonSerializer.Deserialize<CurrencyRate>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { IncludeFields = true });           
        } 
        public async Task<decimal> GetCurrencyAsync(string currencyName)
        {
            if (DateTime.Today.AddDays(-1).ToString("DD-MM-yyyy") != Date)
                await GetNewCurrencyAsync();

            var currentCurrency = Currency.exchangeRate.FirstOrDefault(x => x.currency == currencyName);

            return currentCurrency.saleRate;
        }
    }
}
