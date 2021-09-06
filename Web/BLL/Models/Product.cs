using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public int CompanyId { get; set; }
        public int SellerId { get; set; }
        public string About { get; set; }
        public decimal Price { get; set; }
        public double Count { get; set; }
    }
}
