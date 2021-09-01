using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Interfaces
{
    public interface IFoodOperation
    {
        string Add(Food food);
        string BuyFood(int foodId, double number);
        List<IFoodable> Get();
        IFoodable Get(int id);
        void Delete(int id);
        void Save();
    }
}
