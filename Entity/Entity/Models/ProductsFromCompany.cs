﻿using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class ProductsFromCompany: ProductsFromCompanable
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
        
    }
}
