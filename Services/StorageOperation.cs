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
        private readonly IDataStorage _dataStorage;
        private readonly IMemoryCachable<IFoodable> _memoryCache;
        private readonly IExchangerable _currencyExchanger;
        
        public StorageOperation(IStoredable sameFoods, ILogger logger, IDataStorage dataStorage, IMemoryCachable<IFoodable> memoryCach, IExchangerable currencyExchanger)
        {
            _storage = sameFoods;
            _logger = logger;
            _dataStorage = dataStorage;
            _memoryCache = memoryCach;
            _currencyExchanger = currencyExchanger;
        }       
        public void AddFood(Food food)
        {
            food.Id = _storage.Foods.Max(f => f.Id) + 1;
            _storage.Foods.Add(food);
            _dataStorage.SaveData(_storage.Foods);

            var message = " Put new food Name: " + food.Name + ", Count: "
                + food.Count + ", Price: " + food.Price;

            Speaker.Output(message, "Customer");
            _logger.Log(base.GetType() + message);
        }
        public bool GetFood(int foodId, double number)
        {
            var index = _storage.Foods.FindIndex(f => f.Id == foodId);
            if (index == -1)
                return false;

            if (_storage.Foods[index].Count - number < 1)
                number = _storage.Foods[index].Count;

            var message = " Bought food Name: " + _storage.Foods[index].Name + ", Take: " + number +
                " / " + _storage.Foods[index].Count + ", For price: " + _storage.Foods[index].Price;

            _storage.Foods[index].Count -= number;
            _dataStorage.SaveData(_storage.Foods);
            Speaker.Output(message, "Customer");
            return true;
        }
        public async Task OutputInfoAboutFoodAsync()
        {
            foreach (var food in _storage.Foods)
                await OutputInfoAboutFoodAsync(food.Id);
        }
        public async Task OutputInfoAboutFoodAsync(int foodId)
        {
            var message = default(string);
            var foods = _memoryCache.GetOrCreate(foodId, () => GetObjectById(foodId), out message);

            if (foods is not null)
            {
                Speaker.Output("Food Id - " + foods.Id.ToString() + " " + foods.Name + ", Count - "
                        + foods.Count.ToString() + " UAN - " + foods.Price +
                        " USD - " + foods.Price / await _currencyExchanger.GetCurrencyAsync("USD"));
            }
        }      
        private IFoodable GetObjectById(int foodId)
        {
            return _storage.Foods.FirstOrDefault(f => f.Id == foodId);
        }        
    }
}
