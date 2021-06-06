using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Interfaces
{
    public interface IDataStorage
    {
        bool SaveData<T>(T obj);
        T LoadData<T>(T obj);
        bool CheckStorageDataAvailability();
    }
}
