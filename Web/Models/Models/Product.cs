using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "No Name specified")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Name is to short or long")]
        public string Name { get; set; }
        public string ImageName { get; set; }
        public int CompanyId { get; set; }
        public int SellerId { get; set; }

        [StringLength(90, ErrorMessage = "Text is to long")]
        public string About { get; set; }

        [Required(ErrorMessage = "No Price specified")]
        [Range(1, 9999, ErrorMessage = "Incorrect Price")]
        public decimal Price { get; set; }

        [Range(1, 9999, ErrorMessage = "Incorrect Count")]
        public double Count { get; set; }
    }
}
