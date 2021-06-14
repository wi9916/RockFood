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
        private readonly IDataStorage _dateStorage;
        private readonly MemoryCache<IFoodable> _memoryCach;
        public StorageOperation(IStoredable sameFoods, ILogger logger, IDataStorage dateStorage, MemoryCache<IFoodable> memoryCach)
        {
            _storage = sameFoods;
            _logger = logger;
            _dateStorage = dateStorage;
            _memoryCach = memoryCach;
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
        public void OutputInfoAboutFood()
        {
            foreach (var food in _storage.Foods)
                OutputInfoAboutFood(food.Id);
        }
        public void OutputInfoAboutFood(int foodId)
        {
            var message = default(string);
            var foods = _memoryCach.GetOrCreate(foodId, () => GetObjectById(foodId), out message);

            Speaker.Output(message + "Food Id - " + foods.Id.ToString() + " " + foods.Name + ", Count - "
                + foods.Count.ToString() + " $ - " + foods.Price);
        }
        private IFoodable GetObjectById(int foodId)
        {
            return _storage.Foods.FirstOrDefault(f => f.Id == foodId);
        }
    }
}
