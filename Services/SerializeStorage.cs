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
    public class SerializeStorage: ISerializeStoragable
    {
        private readonly string _folderPath;
        private readonly string _fileName;
        public SerializeStorage(string fileName)
        {
            _fileName = fileName;
            _folderPath = GenerateFolderPath("Serializations");
        }               
        public bool WriteFileSerialize<T>(T obj)
        {           
            if (!Directory.Exists(_folderPath))
                Directory.CreateDirectory(_folderPath);

            var jsonString = JsonSerializer.Serialize(obj);
            File.WriteAllText(Path.Combine(_folderPath, _fileName), jsonString);
            Speaker.Output("Serialization " +  obj.GetType(), "Serializer");

            return true;
        }
        public T ReadFileSerialize<T>(T obj)
        {
            var jsonString = File.ReadAllText(Path.Combine(_folderPath, _fileName));
            Speaker.Output("Desialization " + obj.GetType(), "Serializer");
            return JsonSerializer.Deserialize<T>(jsonString);
        }
        public bool CheckFileAvailability()
        {           
            return File.Exists(Path.Combine(_folderPath, _fileName));
        }    
        private string GenerateFolderPath(string folderName)
        {
            var pathParts = new[]
            {
                AppDomain.CurrentDomain.BaseDirectory,
                folderName
            };
            return Path.Combine(pathParts);
        }
    }
}
