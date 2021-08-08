﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public enum OrderStatus
    {
        None,
        Waiting,
        Confirmation,
        OnTheRoad,
        Performed,
        Denied,
    }
}
