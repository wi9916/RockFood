using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Models
{
    public class DeliveryMan : Person
    {
        public string WorkTime { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public bool WorkNow { get; set; }
    }
}
