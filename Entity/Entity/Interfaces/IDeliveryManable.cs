using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IDeliveryManable: IPersonable
    {
        string WorkTime { get; set; }
        IEnumerable<IOrderable> Orders { get; set; }
        bool IsAvailable { get; set; }
    }
}
