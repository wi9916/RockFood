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
                _storageDate.SaveData(Foods);
            }
            else
            {
                Foods = _storageDate.LoadData(Foods);
            }
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
        public Food GetFoodById(int objectId)
        {
            var food = Foods.FirstOrDefault(f => f.Id == objectId);
            if (food is null)
                return new Food();

            return food;
        }
    }
}
