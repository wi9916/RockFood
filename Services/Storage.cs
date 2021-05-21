using RockFood.Interfaces;
using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Services
{
    public class Storage: IStoredable
    {
        public List<IFoodable> Foods { get; }
        public Storage()
        {
            Foods = new List<IFoodable>();
            CreateNewBaseStorage();
        }
        private void CreateNewBaseStorage()
        {
            Foods.Add(new Food { Id = 1, Name = "The Best Cakes", Price = 20, Count = 100 });
            Foods.Add(new Food { Id = 2, Name = "The Cakes", Price = 30, Count = 100 });
        }
    }
}
