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
        void AddFood(Food food);
        bool GetFood(int foodId, double number);
        void OutputInfoAboutFood();
        void OutputInfoAboutFood(int foodId);       
    }
}
