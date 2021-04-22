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
            DialogInShop st = new DialogInShop();
            st.DialogStartWorking();
            Console.WriteLine("Hello World!");
        }
    }
}
