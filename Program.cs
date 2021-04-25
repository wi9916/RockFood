using RockFood.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood
{  
    class Program
    {
        static void Main(string[] args)
        {
            DialogInShop dialog = new DialogInShop();
            dialog.DialogStartWorking();
            Console.WriteLine("Hello World!");
        }
    }
}
