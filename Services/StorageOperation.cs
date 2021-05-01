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
            Speaker.Output(" new food: " + food.Name, "Put");
            return true;
        }
        public bool TakeFood(int foodId, int number)
        {            
            var index = storage.Foods.FindIndex(f => f.Id == foodId);
            if (index == -1)
                return false;
          
            storage.Foods[index].Count -= number;
            Speaker.Output("You bought " + storage.Foods[index].Name + " for price $" + storage.Foods[index].Price, "Buy");
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

            Speaker.Output("Food Id - " + foods.Id.ToString() + " " + foods.Name + " Count - "
                    + foods.Count.ToString() + " $ - " + foods.Price);

            return true;          
        }       
    }
}
