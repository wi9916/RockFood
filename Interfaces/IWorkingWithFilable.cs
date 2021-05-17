using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Interfaces
{
    public interface IWorkingWithFilable
    {
        public void AppendLine(string fileName, string infoToWrite);
        public void CreateFile(string fileName, string filePath);
        public void CreateFolder(string fileName);       
    }
}
