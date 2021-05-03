using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Interfaces
{
    public interface IStoredOperationable
    {
        bool PutNewFood(IFoodable food);
        bool TakeFood(int foodId, int number);
        bool OutputInfoAboutFood();
        bool OutputInfoAboutFood(int foodId);       
    }
}
