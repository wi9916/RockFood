using RockFood.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Models
{
    public class Food : Product, IFoodable
    {
        public string Composition { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime UseToDate { get; set; }
        public string ProductsTypeName { get; set; }
    }
    
}