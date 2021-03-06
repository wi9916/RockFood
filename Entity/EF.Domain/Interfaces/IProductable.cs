using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IProductable
    {
        int Id { get; set; }
        string Name { get; set; }
        string ImageName { get; set; }
        int CategoryId { get; set; }
        int CompanyId { get; set; }
        string About { get; set; }
        decimal Price { get; set; }
    }
}
