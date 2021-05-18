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
        bool PutNewFood(Food food);
        bool TakeFood(int foodId, double number);
        bool OutputInfoAboutFood();
        bool OutputInfoAboutFood(int foodId);       
    }
}
