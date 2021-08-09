using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    [Table("Product")]
    public class Product: IProductable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public string About { get; set; }
        public decimal Price { get; set; }
    }
}
