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
        private string _productsStore { get; set; }
    }
    public class ProductCollection : ICollection
    {
        public IList<string> ProductTypes;
        
        public ProductCollection()
        {
            ProductTypes = new List<string>() {"Drink","Cake","Salad","Another" };
        }

        public int Count => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
