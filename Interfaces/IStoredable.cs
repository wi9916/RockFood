using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Interfaces
{
    public interface IStoredable
    {
        List<Food> Foods { get; set; }
        bool PutNewFood(Food food);
        bool TakeFood(int foodId, int number);
        bool OutputInfoAboutFood(int foodId);
    }
}
