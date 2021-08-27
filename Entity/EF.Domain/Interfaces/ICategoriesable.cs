using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface ICategoriesable
    {
        int Id { get; set; }
        string Name { get; set; }
        int ParentCategoryId { get; set; }
    }
}
