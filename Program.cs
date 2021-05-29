using RockFood.Interfaces;
using RockFood.Services;
using System;

namespace RockFood
{
    class Program
    {
        static void Main(string[] args)
        {
            var dialog = new DialogInShop(new StorageOperation(new Storage(), new Logger()), new ResidentsOperation(new Residents(), new Logger()));
            dialog.DialogStartWorking();
        }
    }
}
