using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Models
{
    public class Food : Product
    {
        public string Composition { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime UseToDate { get; set; }
        public ProductType? ProductType { get; set; }
    }
    [Flags]
    public enum ProductType
    {
        None,
        Drink,
        Cake,
        Salad,
    }
}
