using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Models
{
    class Food: Product
    {
        public string composition { get; set; }
        public DateTime productionDate { get; set; }
        public DateTime useToDate { get; set; }
    }
}
