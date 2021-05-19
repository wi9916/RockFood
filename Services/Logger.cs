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
        public void Log(string information, string message, MessageTypes messageTypes)
        {
            WriteInFileLog(information,message,messageTypes);
        }
        private void WriteInFileLog(string information, string message, MessageTypes messageTypes)
        {          
            var pathParts = new[]
            {
                AppDomain.CurrentDomain.BaseDirectory,
                information,
                information + DateTime.Today.ToString("d-MM-yyyy") + ".txt"
            };

            var filePath = Path.Combine(pathParts);

            if (!File.Exists(filePath))
                CreateFile(information, filePath);

            using var file = new FileStream(filePath, FileMode.Append);
            using var stream = new StreamWriter(file, Encoding.UTF8);

            stream.AutoFlush = true;
            stream.WriteLine(DateTime.Now.ToString("T") + " " + messageTypes+" => " + message);
        }
        private void CreateFile(string information, string filePath)
        {
            CreateFolder(information);

            using (File.Create(filePath)) { };
        }
        private void CreateFolder(string information)
        {
            var pathParts = new[]
            {
                AppDomain.CurrentDomain.BaseDirectory,
                information
            };
            var folderPath = Path.Combine(pathParts);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
        }        
    }    
}
