using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Models
{
    class DeliveryMan: Person
    {
        public string workTime { get; set; }
        public IEnumerable<Order> orders { get; set; }
        public bool workNow { get; set; }
    }
}
