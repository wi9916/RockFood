using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    [Table("Customer")]
    public class Customer : Person, ICustomerable
    {
        public double Discount { get; set; }
        public string Address { get; set; }
    }
}
