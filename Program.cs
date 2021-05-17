using RockFood.Interfaces;
using RockFood.Services;
using System;

namespace RockFood
{
    class Program
    {
        static void Main(string[] args)
        {
            DialogInShop dialog = new DialogInShop(new StorageOperation(new Storage(), new WorkingWithFiles()), new ResidentsOperation(new Residents(), new WorkingWithFiles()));
            dialog.DialogStartWorking();
        }
    }
}
