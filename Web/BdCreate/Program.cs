using Entity.Data;
using Entity.Data.Repository;
using RockFood.Interfaces;
using RockFood.Services;
using System;

namespace BdCreate
{
    class Program
    {
        public static UnitOfWork _unitOfWork;
        //public static DataContext _context;
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            //_context = new DataContext();
            //_context.Database.EnsureCreated();

            _unitOfWork = new UnitOfWork();

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
            //foreach (var f in sameFoods.Foods)
            //{
            //    f.Id = default;
            //    _unitOfWork.Foods.Create(f);
            //}
            //foreach (var c in samePersons.Customers)
            //{
            //    c.Id = default;
            //    _unitOfWork.Customers.Create(c);
            //}

            
            //_unitOfWork.Save();
            //Console.WriteLine("Create Bd");
            //Console.ReadKey();
            await dialog.DialogStartWorkingAsync();
        }
    }
}
