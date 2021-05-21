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
        void Serialization<T>(T obj, string fileName, string folderPatch);
        T Desialization<T>(T obj, string fileName, string folderPatch);
        bool CheckFile(string fileName, string folderPatch);       
    }
}
