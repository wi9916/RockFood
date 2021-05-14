using RockFood.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Services
{
    public static class WorkingWithFiles
    {      
        public static void AppendLine(string fileName, string infoToWrite)
        {
            var pathParts = new[]
            {
                AppDomain.CurrentDomain.BaseDirectory,
                fileName,
                fileName + DateTime.Today.ToString("d") + ".txt"
            };

            var filePath = Path.Combine(pathParts);

            if (!File.Exists(filePath))
                CreateFile(fileName, filePath);

            using var file = new FileStream(filePath, FileMode.Append);
            using var stream = new StreamWriter(file, Encoding.UTF8);

            stream.AutoFlush = true;
            stream.WriteLine(DateTime.Now.ToString("T") + " => " + infoToWrite);
        }
        public static void CreateFile(string fileName, string filePath)
        {
            CreateFolder(fileName);

            using (File.Create(filePath)) { };
        }
        public static void CreateFolder(string fileName)
        {
            var pathParts = new[]
            {
                AppDomain.CurrentDomain.BaseDirectory,
                fileName
            };
            var folderPath = Path.Combine(pathParts);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
        }
    }
}
