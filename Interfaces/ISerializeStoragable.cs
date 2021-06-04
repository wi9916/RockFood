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
        bool WriteFileSerialize<T>(T obj);
        T ReadFileSerialize<T>(T obj);
        bool CheckFileAvailability();
    }
}
