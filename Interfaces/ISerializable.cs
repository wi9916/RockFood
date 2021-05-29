using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Interfaces
{
    public interface ISerializable
    {
        void Serialize<T>(T obj);
        T Desialization<T>(T obj);
        bool CheckFile();       
    }
}
