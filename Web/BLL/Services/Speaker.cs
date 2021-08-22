using RockFood.Models;
using RockFood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Services
{
    public static class Speaker
    {
        private static readonly Logger _logger = new Logger();
        public static void Output(string message, string messageAuthor = "System")
        {
            Console.WriteLine("{0}: {1}", messageAuthor, message);
            if (messageAuthor != "System")                            
                Console.ReadKey();

            if (messageAuthor == "Error")
                _logger.Log(message,MessageTypes.Error);
        }      
    }
}
