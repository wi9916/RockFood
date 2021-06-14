using RockFood.Interfaces;
using RockFood.Models;
using RockFood.Services;
using System;

namespace RockFood
{
    class Program
    {
        static void Main(string[] args)
        {
            var dialog = new DialogInShop(
                new StorageOperation(new Storage(), new Logger(), new DataStorage("foods"), new MemoryCache<IFoodable>(), new CurrencyExchanger()), 
                new ResidentsOperation(new Residents(), new Logger(), new DataStorage("customers"), new MemoryCache<IPersonable>())
                );
            dialog.DialogStartWorking();
        }
    }
}
