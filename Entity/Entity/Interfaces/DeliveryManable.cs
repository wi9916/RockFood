using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface DeliveryManable: Personable
    {
        string WorkTime { get; set; }
        IEnumerable<Orderable> Orders { get; set; }
        bool IsAvailable { get; set; }
    }
}
