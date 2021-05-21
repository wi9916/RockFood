﻿using RockFood.Interfaces;
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
        private readonly string _folderPath;
        private readonly string _fileName;
        public Serializer(string fileName)
        {
            _fileName = fileName;
            _folderPath = CreateFolderPath("Serializations");
        }               
        public void Serialization<T>(T obj)
        {          
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }

            var jsonString = JsonSerializer.Serialize(obj);
            File.WriteAllText(Path.Combine(_folderPath, _fileName), jsonString);
            Speaker.Output("Serialization " +  obj.GetType(), "Serializer");
        }
        public T Desialization<T>(T obj)
        {
            var jsonString = File.ReadAllText(Path.Combine(_folderPath, _fileName));
            Speaker.Output("Desialization " + obj.GetType(), "Serializer");
            return JsonSerializer.Deserialize<T>(jsonString);
        }
        public bool CheckFile()
        {           
            return File.Exists(Path.Combine(_folderPath, _fileName));
        }    
        private string CreateFolderPath(string folderName)
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
