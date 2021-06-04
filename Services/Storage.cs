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
        private readonly ISerializeStoragable _serializeStorage;
        public List<Food> Foods { get; set; }
        public Storage(ISerializeStoragable serializeStorage)
        {
            _serializeStorage = serializeStorage;
            Foods = new List<Food>();

            if (!_serializeStorage.CheckFileAvailability())
            {
                CreateNewBaseStorage();
                _serializeStorage.WriteFileSerialize(Foods);
            }
            else
            {
                Foods = _serializeStorage.ReadFileSerialize(Foods);
            }
        }
        private void CreateNewBaseStorage()
        {
            Foods.Add(new Food { Id = 1, Name = "The Best Cakes", Price = 20, Count = 100 });
            Foods.Add(new Food { Id = 2, Name = "The Cakes", Price = 30, Count = 100 });
            Foods.Add(new Food { Id = 3, Name = "Same Cakes", Price = 10, Count = 5 });
            Foods.Add(new Food { Id = 4, Name = "Gem", Price = 10, Count = 5 });
        }
        public void AddItem(Food item)
        {
            item.Id = Foods.Max(f => f.Id) + 1;
            Foods.Add(item);
            _serializeStorage.WriteFileSerialize(Foods);
        }
        public bool GetItem(Food item)
        {
            var index = Foods.FindIndex(f => f.Id == item.Id);
            if (index == -1)
                return false;

            Foods[index] = item;
            _serializeStorage.WriteFileSerialize(Foods);

            return true;
        }
        public Food GetFoodById(int itemId)
        {
            return Foods.FirstOrDefault(f => f.Id == itemId);
        }
    }
}
