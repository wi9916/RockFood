using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IDeliverable
    {
        int Id { get; set; }
        int DeliveryDistance { get; set; }
        double SizeMin { get; set; }
        double SizeMax { get; set; }
        decimal Price { get; set; }
    }
}
