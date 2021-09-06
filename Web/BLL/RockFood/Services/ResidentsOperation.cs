using RockFood.Interfaces;
using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Services
{
    public class ResidentsOperation: IResidentOperationable
    {
        private readonly IResidentable _storage;
        private readonly DataStorage _dataStorage;
        private readonly IMemoryCacheable<IPersonable> _memoryCache;
        public ResidentsOperation(IResidentable samePersons, DataStorage dataStorage, IMemoryCacheable<IPersonable> memoryCach)
        {
            _storage = samePersons;
            _dataStorage = dataStorage;
            _memoryCache = memoryCach;
        }
        public bool AddCustomer(Customer person)
        {
            if (_storage.Customers is null)
                return false;

            person.Id = _storage.Customers.Max(f => f.Id) + 1;
            var message = " Create new customer Name: " + person.Name;
            Speaker.Output(message, "Create");
            _dataStorage.SaveData(_storage.Customers);

            return true;
        }
        public void OutputCustomerInfo()
        {
            foreach (var customer in _storage.Customers)
                OutputCustomerInfoById(customer.Id);
        }
        public void OutputCustomerInfoById(int customerId)
        {
            var message = default(string);
            var customer = _memoryCache.GetOrCreate(customerId, () => GetObjectById(customerId), out message);
            Speaker.Output(message + "Person Id - " + customer.Id.ToString() + " Name - " + customer.Name);
        }
        private IPersonable GetObjectById(int customerId)
        {
            return _storage.Customers.FirstOrDefault(f => f.Id == customerId);
        }       
    }
}
