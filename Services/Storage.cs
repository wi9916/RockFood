using RockFood.Interfaces;
using RockFood.Models;
using RockFood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood
{
    public class Storage: IStoredable
    {
        public List<Food> Foods { get; set; }
        public Storage()
        {
            string fileSerializer = "foods";
            var ser = new Serializer();
            Foods = new List<Food>();
            
            if (ser.CheckFile(fileSerializer))
            {
                Foods = ser.Desialization(Foods, fileSerializer);
            }
            else
            {
                CreateNewBaseStorage();
                ser.Serialization(Foods, fileSerializer);
            }
            
        }
        private void CreateNewBaseStorage()
        {
            Foods.Add(new Food { Id = 1, Name = "The Best Cakes", Price = 20, Count = 100 });
            Foods.Add(new Food { Id = 2, Name = "The Cakes", Price = 30, Count = 100 });
            Foods.Add(new Food { Id = 3, Name = "Same Cakes", Price = 10, Count = 5 });
            Foods.Add(new Food { Id = 4, Name = "Gem", Price = 10, Count = 5 });
        }

    }
}
