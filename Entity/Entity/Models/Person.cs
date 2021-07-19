using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Person: Personable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string About { get; set; }
    }
}
