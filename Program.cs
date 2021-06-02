using RockFood.Interfaces;
using RockFood.Services;
using System;

namespace RockFood
{
    class Program
    {
        static void Main(string[] args)
        {
            var dialog = new DialogInShop(new StorageOperation(new Storage(new SerializeStorage("foods")), new Logger()), 
                new ResidentsOperation(new Residents(new SerializeStorage("customers")), new Logger()));
            dialog.DialogStartWorking();
        }
    }
}
