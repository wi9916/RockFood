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
        public StorageOperation()
        {
            storage = new Storage();          
        }
        public StorageOperation(IStoredable sameFoods)
        {
            storage = sameFoods;
        }
        
        public bool PutNewFood(IFoodable food)
        {
            food.Id = storage.Foods.Count();
            storage.Foods.Add(food);
            Speaker.Output("new food: " + food.Name, "Put");
            return true;
        }
        public bool TakeFood(int foodId, int number)
        {
            var index = storage.Foods.FindIndex(f => f.Id == foodId);
            if (index >= 0)
            {
                storage.Foods[index].Count -= number;
                Speaker.Output("You bought " + storage.Foods[index].Name + " for price $" + storage.Foods[index].Price, "Buy");
                return true;
            }
            return false;
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
            var index = storage.Foods.FindIndex(f => f.Id == foodId);
            if (index >= 0)
            {
                Speaker.Output("Id - " + storage.Foods[index].Id.ToString() + " " + storage.Foods[index].Name + " Count - "
                    + storage.Foods[index].Count.ToString() + " $ - " + storage.Foods[index].Price);
                return true;
            }
            return false;
        }       
    }
}
