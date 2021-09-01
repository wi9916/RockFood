using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Interfaces
{
    public interface IFoodable
    {
        int Id { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
        double Count { get; set; }
        string About { get; set; }
    }
}
