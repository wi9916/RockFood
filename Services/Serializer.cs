using RockFood.Interfaces;
using RockFood.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RockFood.Services
{
    public class Serializer: ISerializable
    {
        private const string _folderPatch = "Serializations/";
        public void Serialization(List<Food> obj,string fileName,string folderPatch = _folderPatch)
        {
            if (!Directory.Exists(folderPatch))
            {
                Directory.CreateDirectory(folderPatch);
            }

            var jsonString = JsonSerializer.Serialize(obj);
            File.WriteAllText(folderPatch + fileName, jsonString);          
        }
        public List<Food> Desialization(string fileName, string folderPatch = _folderPatch)
        {
            var jsonString = File.ReadAllText(folderPatch + fileName);           
            return JsonSerializer.Deserialize<List<Food>>(jsonString);
        }
        public bool CheckFile(string fileName, string folderPatch = _folderPatch)
        {                     
            return File.Exists(folderPatch + fileName);
        }

    }
}
