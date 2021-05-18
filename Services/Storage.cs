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
            var ser = new Serializer();
            Foods = new List<Food>();

            if (ser.CheckFile("foods"))
            {
                Foods = ser.Desialization("foods");             
            }
            else
            {
                CreateNewBaseStorage();
                ser.Serialization(Foods, "foods");
            }
            
        }
        private void CreateNewBaseStorage()
        {
            Foods.Add(new Food { Id = 1, Name = "The Best Cakes", Price = 20, Count = 100 });
            Foods.Add(new Food { Id = 2, Name = "The Cakes", Price = 30, Count = 100 });
            Foods.Add(new Food { Id = 3, Name = "Same Cakes", Price = 10, Count = 5 });
        }
    }
}
