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
    public class DataStorage: IDataStorage
    {
        private readonly string _folderPath;
        private readonly string _fileName;
        public DataStorage(string fileName)
        {
            var pathParts = new[]
            {
                AppDomain.CurrentDomain.BaseDirectory,
                "Serializations"
            };

            _folderPath = Path.Combine(pathParts);
            _fileName = fileName;                       
        }               
        public bool SaveData<T>(T obj)
        {           
            if (!Directory.Exists(_folderPath))
                Directory.CreateDirectory(_folderPath);

            var jsonString = JsonSerializer.Serialize(obj);
            File.WriteAllText(Path.Combine(_folderPath, _fileName), jsonString);           

            return true;
        }
        public T LoadData<T>(T obj)
        {
            var jsonString = File.ReadAllText(Path.Combine(_folderPath, _fileName));
            return JsonSerializer.Deserialize<T>(jsonString);
        }
        public bool CheckStorageDataAvailability()
        {           
            return File.Exists(Path.Combine(_folderPath, _fileName));
        }            
    }
}
