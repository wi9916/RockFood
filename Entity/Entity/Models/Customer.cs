﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public double Discount { get; set; }
        public string Address { get; set; }
    }
}
