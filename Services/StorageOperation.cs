﻿using RockFood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Interfaces
{
    public class StorageOperation : IStoredOperationable
    {
        private readonly IStoredable storage;      
        public StorageOperation(IStoredable sameFoods)
        {
            storage = sameFoods;
        }
        
        public bool PutNewFood(IFoodable food)
        {
            if (storage is null)
                return false;

            food.Id = storage.Foods.Max(f => f.Id) + 1;
            storage.Foods.Add(food);

            var message = "Put new food Name: " + food.Name + ", Count: "
                + food.Count + ", Price: " + food.Price;

            Speaker.Output(message, "Customer");
            WorkingWithFiles.AppendLine("LoggerBase", message);
            return true;
        }
        public bool TakeFood(int foodId, int number)
        {            
            var index = storage.Foods.FindIndex(f => f.Id == foodId);
            if (index == -1)
                return false;

            var message = "Bought food Name: " + storage.Foods[index].Name + ", Count: "
                + storage.Foods[index].Count + ", Price: " + storage.Foods[index].Price;

            storage.Foods[index].Count -= number;
            Speaker.Output(message, "Customer");

            message = "Bought food Name: " + storage.Foods[index].Name + ", Take: " + number +
                " / " + storage.Foods[index].Count + ", For price: " + storage.Foods[index].Price * number;

            WorkingWithFiles.AppendLine("LoggerBase", message);
            return true;
        }
        public bool OutputInfoAboutFood()
        {
            foreach (var food in storage.Foods)
                if (!OutputInfoAboutFood(food.Id))
                {
                    Speaker.Output("Output Error", "Error");
                    return false;
                }

            return true;
        }
        public bool OutputInfoAboutFood(int foodId)
        {
            var foods = storage.Foods.FirstOrDefault(f => f.Id == foodId);
            if (foods is null)
                return false;

            Speaker.Output("Food Id - " + foods.Id.ToString() + " " + foods.Name + ", Count - "
                    + foods.Count.ToString() + " $ - " + foods.Price);

            return true;          
        }       
    }
}
