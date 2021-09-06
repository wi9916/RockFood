using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public enum OrderStatus
    {
        None,
        Waiting,
        Confirmation,
        OnTheRoad,
        Performed,
        Denied,
    }
}
