﻿using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    [Table("Company")]
    public class Company: ICompanable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public string About { get; set; }
        //public List<Product> Products { get; set; }
        public Company()
        {
           // Products = new List<Product>();
        }
    }
}
