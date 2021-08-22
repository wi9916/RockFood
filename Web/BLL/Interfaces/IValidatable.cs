using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Interfaces
{
    public interface IValidatable
    {        
        bool CheckPhone(string phoneNumber);
        bool CheckAddress(string address);
    }
}
