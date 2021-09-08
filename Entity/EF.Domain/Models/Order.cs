using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Order
    {    
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string AddressOfDelivery { get; set; }
        public int CustomerId { get; set; }
        public int DeliveryId { get; set; }
        public OrderStatus Status { get; set; }
        public IEnumerable<int> ProductsId { get; set; }
        public decimal TotalPrice { get; set; }
    }   
}
