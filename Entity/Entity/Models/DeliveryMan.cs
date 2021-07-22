using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class DeliveryMan : Person, IDeliveryManable
    {
        public string WorkTime { get; set; }
        public IEnumerable<IOrderable> Orders { get; set; }
        public bool IsAvailable { get; set; }
    }
}
