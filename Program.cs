using RockFood.Interfaces;
using RockFood.Models;
using RockFood.Services;
using System;

namespace RockFood
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var sameFoods = new Storage();
            var foodDataStorage = new DataStorage("foods");
            sameFoods.Foods = foodDataStorage.LoadData(sameFoods.Foods);

            var samePersons = new Residents();
            var customerDataStorage = new DataStorage("customers");
            samePersons.Customers = customerDataStorage.LoadData(samePersons.Customers);

            var dialog = new DialogInShop(
                new StorageOperation(sameFoods, new Logger(), foodDataStorage, new MemoryCache<IFoodable>(), new CurrencyExchanger()),
                new ResidentsOperation(samePersons, new Logger(), customerDataStorage, new MemoryCache<IPersonable>())
                );
            await dialog.DialogStartWorkingAsync();          
        }
    }
}
