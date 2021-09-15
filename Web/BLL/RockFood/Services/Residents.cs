using RockFood.Interfaces;
using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Services
{
    public class Residents : IResidentable
    {
        public List<Customer> Customers { get; set; }
        public Residents()
        {
            Customers = new List<Customer>();
        }
    }
}
