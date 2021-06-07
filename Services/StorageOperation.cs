using RockFood.Interfaces;
using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Services
{
    public class StorageOperation : IStoredOperationable
    {
        private readonly IStoredable _storage;
        private readonly ILogger _logger;
        private readonly IExchangerable _currencyExchanger;
        public StorageOperation(IStoredable sameFoods, ILogger logger, IExchangerable currencyExchanger)
        {
            _storage = sameFoods;
            _logger = logger;
            _currencyExchanger = currencyExchanger;
        }
        
        public void AddFood(Food food)
        {
            _storage.AddFood(food);

            var message = " Put new food Name: " + food.Name + ", Count: "
                + food.Count + ", Price: " + food.Price;

            Speaker.Output(message, "Customer");
            _logger.Log(base.GetType() + message);
        }
        public bool GetFood(int foodId, double number)
        {
            var food = _storage.GetFoodById(foodId);
            if(food == default)
                return false;           

            if(food.Count - number < 1)
                number = food.Count;

            if (!_storage.GetFood(food))
                return false;

            var message = " Bought food Name: " + food.Name + ", Take: " + number +
                " / " + food.Count + ", For price: " + food.Price;

            food.Count -= number;
            Speaker.Output(message, "Customer");

            return true;
        }
        public async Task GetFoodInfoAsync()
        {
            foreach (var food in _storage.Foods)
               await GetFoodInfoByIdAsync(food.Id);               
        }
        public async Task GetFoodInfoByIdAsync(int foodId)
        {
            var foods = _storage.GetFoodById(foodId);
            if (foods is not null)
            {
                Speaker.Output("Food Id - " + foods.Id.ToString() + " " + foods.Name + ", Count - "
                        + foods.Count.ToString() + " UAN - " + foods.Price +
                        " USD - " + foods.Price / await _currencyExchanger.GetCurrencyAsync("USD"));
            }
        }       
    }
}
