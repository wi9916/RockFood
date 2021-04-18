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
        public DateTime CreatedDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int CustomerId { get; set; }
        public OrderStatus orderStatus { get; set; }
        public IEnumerable<Food> Foods { get; set; }
        public IEnumerable<Product> Containers { get; set; }
    }
    public enum OrderStatus
    {
        None,
        Waiting,
        Confirmation,
        OnTheRoad,
        Performed,
        Denied,
    }
}
