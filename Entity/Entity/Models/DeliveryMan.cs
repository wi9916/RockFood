using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class DeliveryMan : Person, DeliveryManable
    {
        public string WorkTime { get; set; }
        public IEnumerable<Orderable> Orders { get; set; }
        public bool IsAvailable { get; set; }
    }
}
