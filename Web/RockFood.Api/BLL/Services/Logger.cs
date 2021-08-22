using RockFood.Interfaces;
using RockFood.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Services
{
    public class Logger: ILogger
    {
        private const string _fileName = "Logger";
        private const string _directoryName = "Logger";
        public void Log(string message, MessageTypes messageTypes)
        {
            WriteInFileLog(message,messageTypes);
        }
        private void WriteInFileLog(string message, MessageTypes messageTypes)
        {          
            var pathParts = new[]
            {
                AppDomain.CurrentDomain.BaseDirectory,
                _directoryName
            };
            var folderPath = Path.Combine(pathParts);
            var filePath = Path.Combine(folderPath, _fileName + DateTime.Today.ToString("DD-MM-yyyy") + ".txt");

            if (!File.Exists(filePath))
                CreateFile(filePath, folderPath);

            using var file = new FileStream(filePath, FileMode.Append);
            using var stream = new StreamWriter(file, Encoding.UTF8);

            stream.AutoFlush = true;
            stream.WriteLine(DateTime.Now.ToString("T") + " " + messageTypes+" => " + message);
        }
        private void CreateFile(string filePath, string folderPath)
        {         
            CreateFolder(folderPath);
            using (File.Create(filePath)) { };
        }
        private void CreateFolder(string folderPath)
        {           
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
        }        
    }    
}
