﻿using RockFood.Models;
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
        void AddFood(Food item);
        bool GetFood(Food item);
        Food GetFoodById(int itemId);       
    }
}
