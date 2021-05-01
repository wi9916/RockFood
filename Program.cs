using RockFood.Interfaces;
using RockFood.Services;
using System;

namespace RockFood
{
    class Program
    {
        static void Main(string[] args)
        {
            DialogInShop dialog = new DialogInShop(new StorageOperation(new Storage()), new ResidentsOperation(new Residents()));
            dialog.DialogStartWorking();
        }
    }
}
