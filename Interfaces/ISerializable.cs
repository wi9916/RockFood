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
        public void Serialization(List<Food> obj, string fileName, string folderPatch);
        public List<Food> Desialization(string fileName, string folderPatch);
        public bool CheckFile(string fileName, string folderPatch);       
    }
}
