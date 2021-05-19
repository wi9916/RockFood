using RockFood.Models;
using RockFood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Interfaces
{
    public class StorageOperation : IStoredOperationable
    {
        private readonly IStoredable _storage;
        private readonly ILogger _logger;
        public StorageOperation(IStoredable sameFoods, ILogger logger)
        {
            _storage = sameFoods;
            _logger = logger;
        }
        
        public bool PutNewFood(IFoodable food)
        {
            if (_storage is null)
                return false;

            food.Id = _storage.Foods.Max(f => f.Id) + 1;
            _storage.Foods.Add(food);

            var message = "Put new food Name: " + food.Name + ", Count: "
                + food.Count + ", Price: " + food.Price;

            Speaker.Output(message, "Customer");
            _logger.Log("Logger", message, MessageTypes.Storag);
            return true;
        }
        public bool TakeFood(int foodId, double number)
        {            
            var index = _storage.Foods.FindIndex(f => f.Id == foodId);
            if (index == -1)
                return false;

            if(_storage.Foods[index].Count- number < 1)
                number = _storage.Foods[index].Count;            

            var message = "Bought food Name: " + _storage.Foods[index].Name + ", Take: " + number +
                " / " + _storage.Foods[index].Count + ", For price: " + _storage.Foods[index].Price;

            _storage.Foods[index].Count -= number;
            Speaker.Output(message, "Customer");
            _logger.Log("Logger", message,MessageTypes.Storag);
            return true;
        }
        public bool OutputInfoAboutFood()
        {
            foreach (var food in _storage.Foods)
                if (!OutputInfoAboutFood(food.Id))
                {
                    Speaker.Output("Output Error", "Error");
                    return false;
                }

            return true;
        }
        public bool OutputInfoAboutFood(int foodId)
        {
            var foods = _storage.Foods.FirstOrDefault(f => f.Id == foodId);
            if (foods is null)
                return false;

            Speaker.Output("Food Id - " + foods.Id.ToString() + " " + foods.Name + ", Count - "
                    + foods.Count.ToString() + " $ - " + foods.Price);

            return true;          
        }       
    }
}
