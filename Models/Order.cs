using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Models
{
    class Order
    {    
        public int orderId { get; set; }
        public DateTime dateCreate { get; set; }
        public DateTime dateDelivery { get; set; }
        public int customerId { get; set; }
        public bool orderStatus { get; set; }
        public IEnumerable<Food> foods { get; set; }
        public IEnumerable<Container> containers { get; set; }
    }
}
