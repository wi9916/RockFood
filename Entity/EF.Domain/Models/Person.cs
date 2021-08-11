using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string About { get; set; }       
        //public string TestFild { get; set; }        
        //public Customer Customer { get; set; }

        public List<Customer> Customers = new List<Customer>();
        //public string Test { get; set; }
        [NotMapped]
        public string TestNoMappedString { get; set; }
        [NotMapped]
        public int NameLetterCount
        {
            get
            {
                return Name.Length;
            }
        }
    }
}
