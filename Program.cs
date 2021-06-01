using RockFood.Interfaces;
using RockFood.Services;
using System;

namespace RockFood
{
    class Program
    {
        static void Main(string[] args)
        {
            var dialog = new DialogInShop(
                new StorageOperation(new Storage(), new Logger(), new MemoryCache<IFoodable>()), 
                new ResidentsOperation(new Residents(), new Logger(), new MemoryCache<IPersonable>()));
            dialog.DialogStartWorking();
        }
    }
}
