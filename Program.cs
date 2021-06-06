using RockFood.Interfaces;
using RockFood.Services;
using System;

namespace RockFood
{
    class Program
    {
        static void Main(string[] args)
        {
            var dialog = new DialogInShop(new StorageOperation(new Storage(new DataStorage("foods")), new Logger()), 
                new ResidentsOperation(new Residents(new DataStorage("customers")), new Logger()));
            dialog.DialogStartWorking();
        }
    }
}
