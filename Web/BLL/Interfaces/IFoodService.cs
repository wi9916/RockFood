using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Interfaces
{
    public interface IFoodService
    {
        string Add(Food food);
        string BuyFood(int foodId, double number = 1);
        List<IFoodable> Get();
        IFoodable Get(int id);
        void Edit(Food food);
        void Delete(int id);
        void Save();
    }
}
