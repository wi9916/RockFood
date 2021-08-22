using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Customer 
    {
        public int Id { get; set; }
        public double Discount { get; set; }
        public string Address { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
