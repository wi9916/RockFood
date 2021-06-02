using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Interfaces
{
    public interface ISerializeStoragable
    {
        bool Serialize<T>(T obj, bool rewriteFile = false);
        T Desialize<T>(T obj);      
    }
}
