using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Models
{
    public class Order
    {    
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int CustomerId { get; set; }
        public OrderStatus Status { get; set; }
        public IEnumerable<Food> Foods { get; set; }
        public IEnumerable<Product> Containers { get; set; }
    }   
}
