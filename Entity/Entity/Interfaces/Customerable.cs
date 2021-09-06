﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface Customerable: Personable
    {
        double Discount { get; set; }
        string Address { get; set; }
    }
}
