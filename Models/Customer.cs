﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood
{
    public class Customer : Person
    {
        public double Discount { get; set; }
        public string Address { get; set; }
    }
}