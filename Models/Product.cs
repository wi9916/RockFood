using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood
{
    class Product
    {
        public int productId { get; set; }
        public string name { get; set; }
        public string imageName { get; set; }
        public int companyId { get; set; }
        public int sellerId { get; set; }
        public string aboutItem { get; set; }
        public decimal prise { get; set; }
        public double count { get; set; }
    }
}
