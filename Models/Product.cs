using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public int BompanyId { get; set; }
        public int SellerId { get; set; }
        public string AboutItem { get; set; }
        public decimal Prise { get; set; }
        public double Count { get; set; }
    }
}
