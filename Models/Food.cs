using System;
using System.Collections;
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
        public string ProductType { get; set; }
    }
    public class ProductTypeName : IEnumerable
    {
        public IList<string> ProductTypes;
        public IEnumerator GetEnumerator()
        {
            return ProductTypes.GetEnumerator();
        }
        public ProductTypeName()
        {
            ProductTypes = new List<string>() {"Drink","Cake","Salad","Another" };
        }

    }
}
