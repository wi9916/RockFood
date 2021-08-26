using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface Orderable
    {
        int Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime DeliveryDate { get; set; }
        string AddressOfDelivery { get; set; }
        int CustomerId { get; set; }
        int DeliveryId { get; set; }
        OrderStatus Status { get; set; }
        IEnumerable<int> ProductsId { get; set; }
        decimal TotalPrice { get; set; }
    }
}
