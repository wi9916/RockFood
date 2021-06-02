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
        private readonly MemoryCache<IFoodable> _memoryCach;
        public StorageOperation(IStoredable sameFoods, ILogger logger, MemoryCache<IFoodable> memoryCach)
        {
            _memoryCach = memoryCach; ;
            _storage = sameFoods;
            _logger = logger;
        }
        
        public bool PutNewFood(Food food)
        {
            if (_storage is null)
                return false;

            food.Id = _storage.Foods.Max(f => f.Id) + 1;
            _storage.Foods.Add(food);

            var message = " Put new food Name: " + food.Name + ", Count: "
                + food.Count + ", Price: " + food.Price;

            Speaker.Output(message, "Customer");
            _logger.Log(base.GetType() + message);
            return true;
        }
        public bool TakeFood(int foodId, double number)
        {            
            var index = _storage.Foods.FindIndex(f => f.Id == foodId);
            if (index == -1)
                return false;

            if(_storage.Foods[index].Count- number < 1)
                number = _storage.Foods[index].Count;            

            var message = " Bought food Name: " + _storage.Foods[index].Name + ", Take: " + number +
                " / " + _storage.Foods[index].Count + ", For price: " + _storage.Foods[index].Price;

            _storage.Foods[index].Count -= number;
            Speaker.Output(message, "Customer");

            _logger.Log(base.GetType() + message);
            return true;
        }
        public void OutputInfoAboutFood()
        {
            foreach (var food in _storage.Foods)
                OutputInfoAboutFood(food.Id);                

        }
        public void OutputInfoAboutFood(int foodId)
        {
            var message = default(string);
            var foods = _memoryCach.GetOrCreate(foodId, () => _storage.GetObject(foodId), out message);

            Speaker.Output(message + "Food Id - " + foods.Id.ToString() + " " + foods.Name + ", Count - "
                + foods.Count.ToString() + " $ - " + foods.Price);
        }
    }
}
