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
        private readonly IStoragDatable _storageDate;
        public List<Food> Foods { get; set; }
        public Storage(IStoragDatable storageDate)
        {
            _storageDate = storageDate;
            Foods = new List<Food>();

            if (!_storageDate.CheckFileAvailability())
            {
                CreateNewBaseStorage();
                _storageDate.WriteFile(Foods);
            }
            else
            {
                Foods = _storageDate.ReadFile(Foods);
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
            _storageDate.WriteFile(Foods);
        }
        public bool GetItem(Food item)
        {
            var index = Foods.FindIndex(f => f.Id == item.Id);
            if (index == -1)
                return false;

            Foods[index] = item;
            _storageDate.WriteFile(Foods);

            return true;
        }
        public Food GetItemById(int itemId)
        {
            return Foods.FirstOrDefault(f => f.Id == itemId);
        }
    }
}
