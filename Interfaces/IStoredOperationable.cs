using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Interfaces
{
    public interface IStoredOperationable
    {
        bool AddFood(Food food);
        bool GetFood(int foodId, double number);
        bool GetFoodInfo();
        bool GetFoodInfoById(int foodId);       
    }
}
