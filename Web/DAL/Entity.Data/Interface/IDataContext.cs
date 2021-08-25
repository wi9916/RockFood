﻿using Microsoft.EntityFrameworkCore;
using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Data.Interface
{
    public interface IDataContext    
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
