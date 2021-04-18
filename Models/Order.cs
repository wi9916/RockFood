using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Models
{
    public class Order
    {    
        public int OrderId { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateDelivery { get; set; }
        public int CustomerId { get; set; }
        public bool OrderStatus { get; set; }
        public IEnumerable<Food> Foods { get; set; }
        public IEnumerable<Product> Containers { get; set; }
    }
}
