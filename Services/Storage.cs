using RockFood.Interfaces;
using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Services
{
    public class Storage : IStoredable
    {
        private readonly IDataStorage _storageDate;
        public List<Food> Foods { get; set; }
        public Storage(IDataStorage storageDate)
        {
            _storageDate = storageDate;
            Foods = new List<Food>();

            if (!_storageDate.CheckStorageDataAvailability())
            {
                CreateNewBaseStorage();
                _storageDate.SaveData(Foods);
            }
            else
            {
                Foods = _storageDate.LoadData(Foods);
            }
        }
        private void CreateNewBaseStorage()
        {
            Foods.Add(new Food { Id = 1, Name = "The Best Cakes", Price = 20, Count = 100 });
            Foods.Add(new Food { Id = 2, Name = "The Cakes", Price = 30, Count = 100 });
            Foods.Add(new Food { Id = 3, Name = "Same Cakes", Price = 10, Count = 5 });
            Foods.Add(new Food { Id = 4, Name = "Gem", Price = 10, Count = 5 });
        }
        public void AddFood(Food item)
        {
            item.Id = Foods.Max(f => f.Id) + 1;
            Foods.Add(item);
            _storageDate.SaveData(Foods);
        }
        public bool GetFood(Food item)
        {
            var index = Foods.FindIndex(f => f.Id == item.Id);
            if (index == -1)
                return false;

            Foods[index] = item;
            _storageDate.SaveData(Foods);

            return true;
        }
        public Food GetFoodById(int itemId)
        {
            return Foods.FirstOrDefault(f => f.Id == itemId);
        }
    }
}
