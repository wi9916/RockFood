using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class DeliveryType
    {
        public int Id { get; set; }        
        public int DeliveryDistance { get; set; }
        public double SizeMin { get; set; }
        public double SizeMax { get; set; }
        public decimal Price { get; set; }
    }
}
