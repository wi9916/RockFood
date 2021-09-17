using RockFood.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Models
{
    public class Customer : Person, IPersonable
    {
        public double Discount { get; set; }
        public string Address { get; set; }
    }
}
