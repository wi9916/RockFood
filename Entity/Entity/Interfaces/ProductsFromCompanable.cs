using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface ProductsFromCompanable
    {
        int Id { get; set; }
        int CompanyId { get; set; }
        int ProductId { get; set; }
    }
}
