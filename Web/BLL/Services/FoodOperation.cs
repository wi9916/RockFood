using Entity.Data;
using Entity.Data.Interface;
using Microsoft.EntityFrameworkCore;
using RockFood.Interfaces;
using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Services
{
    public class FoodOperation: IFoodOperation
    {
        private readonly DataContext _db;
        private readonly ILogger _logger;
        private readonly IMemoryCacheable<IFoodable> _memoryCache;
        private readonly IExchangerable _currencyExchanger;

        public FoodOperation(DataContext dataContext, ILogger logger, IMemoryCacheable<IFoodable> memoryCache, IExchangerable currencyExchanger)
        {
            _db = dataContext;
            _logger = logger;
            _memoryCache = memoryCache;
            _currencyExchanger = currencyExchanger;
        }
        public string Add(Food food)
        {
            _db.Foods.Add(food);

            var message = " Put new food Name: " + food.Name + ", Count: "
                + food.Count + ", Price: " + food.Price;
          
            _logger.Log(base.GetType() + message);
            return message;
        }
        public string BuyFood(int foodId, double number = 1)
        {
            var food = _db.Foods.Find(foodId);
            if (food is null)
                return "Error";

            if (food.Count - number < 1)
                number = food.Count;

            var message = " Bought food Name: " + food.Name + ", Take: " + number +
                " / " + food.Count + ", For price: " + food.Price;

            food.Count -= number;
            _db.Entry(food).State = EntityState.Modified;
            return message;
        }
        public async Task<List<string>> GetAsync()
        {
            var foods = new List<string>();
            foreach (var food in _db.Foods)
                foods.Add( await GetAsync(food.Id));

            return foods;
        }
        public async Task<string> GetAsync(int id)
        {
            var message = default(string);
            var foods = _memoryCache.GetOrCreate(id, () => _db.Foods.Find(id), out message);
            if (foods is not null)
            {
                message ="Food Id - " + foods.Id.ToString() + " " + foods.Name + ", Count - "
                         + foods.Count.ToString() + " UAN - " + foods.Price + " USD - "
                         + Decimal.Round(foods.Price / await _currencyExchanger.GetExchangeRateAsync("USD"));                
            }
            return message;
        }
        public void Delete(int id)
        {
            Food food = _db.Foods.Find(id);
            if (food != null)
                _db.Foods.Remove(food);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
