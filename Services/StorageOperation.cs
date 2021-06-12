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
        private readonly IDataStorage _dateStorage;
        public StorageOperation(IStoredable sameFoods, ILogger logger, IDataStorage dateStorage)
        {
            _storage = sameFoods;
            _logger = logger;
            _dateStorage = dateStorage;
            _storage.Foods = _dateStorage.LoadData(_storage.Foods);            
        }
        
        public void AddFood(Food food)
        {
            food.Id = _storage.Foods.Max(f => f.Id) + 1;
            _storage.Foods.Add(food);
            _dateStorage.SaveData(_storage.Foods);

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

            if(_storage.Foods[index].Count - number < 1)
                number = _storage.Foods[index].Count;

            var message = " Bought food Name: " + _storage.Foods[index].Name + ", Take: " + number +
                " / " + _storage.Foods[index].Count + ", For price: " + _storage.Foods[index].Price;

            _storage.Foods[index].Count -= number;
            _dateStorage.SaveData(_storage.Foods);
            Speaker.Output(message, "Customer");
            return true;
        }
        public bool GetFoodInfo()
        {
            foreach (var food in _storage.Foods)
                if (!GetFoodInfoById(food.Id))
                {
                    Speaker.Output("Output Error", "Error");
                    return false;
                }

            return true;
        }
        public bool GetFoodInfoById(int foodId)
        {
            var food = _storage.Foods.FirstOrDefault(f => f.Id == foodId);;
            if (food is null)
                return false;

            Speaker.Output("Food Id - " + food.Id.ToString() + " " + food.Name + ", Count - "
                    + food.Count.ToString() + " $ - " + food.Price);

            return true;          
        }       
    }
}
