﻿using RockFood.Interfaces;
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
        public StorageOperation(IStoredable sameFoods, ILogger logger)
        {
            _storage = sameFoods;
            _logger = logger;
        }
        
        public void AddFood(Food food)
        {
            _storage.AddItem(food);

            var message = " Put new food Name: " + food.Name + ", Count: "
                + food.Count + ", Price: " + food.Price;

            Speaker.Output(message, "Customer");
            _logger.Log(base.GetType() + message);
        }
        public bool GetFood(int foodId, double number)
        {
            var food = _storage.GetItemById(foodId);
            if(food == default)
                return false;           

            if(food.Count - number < 1)
                number = food.Count;

            if (!_storage.GetItem(food))
                return false;

            var message = " Bought food Name: " + food.Name + ", Take: " + number +
                " / " + food.Count + ", For price: " + food.Price;

            food.Count -= number;
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
            var foods = _storage.GetItemById(foodId);
            if (foods is null)
                return false;

            Speaker.Output("Food Id - " + foods.Id.ToString() + " " + foods.Name + ", Count - "
                    + foods.Count.ToString() + " $ - " + foods.Price);

            return true;          
        }       
    }
}
