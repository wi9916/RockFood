using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IPersonable
    {
        int Id { get; set; }
        string Name { get; set; }
        string ImageName { get; set; }
        string PhoneNumber { get; set; }
        string Email { get; set; }
        string About { get; set; }
    }
}
