using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface ICustomerable
    {
        int Id { get; set; }
        double Discount { get; set; }
        string Address { get; set; }
        int PersonId { get; set; }    
        IPersonable Person { get; set; }
    }
}
