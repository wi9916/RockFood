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
        private readonly ILogger _logger;
        private readonly DataStorage _dateStorage;
        private readonly MemoryCache<IPersonable> _memoryCach;
        public ResidentsOperation(IResidentable samePersons, ILogger logger, DataStorage dateStorage, MemoryCache<IPersonable> memoryCach)
        {
            _storage = samePersons;
            _logger = logger;
            _dateStorage = dateStorage;
            _memoryCach = memoryCach;
            _storage.Customers = _dateStorage.LoadData(_storage.Customers);
        }
        public bool AddCustomer(Customer person)
        {
            if (_storage.Customers is null)
                return false;

            person.Id = _storage.Customers.Max(f => f.Id) + 1;            
            var message = " Create new customer Name: " + person.Name;            
            Speaker.Output(message, "Create");
            _logger.Log(base.GetType() + message);
            _dateStorage.SaveData(_storage.Customers);

            return true;          
        }
        public void GetCustomerInfo()
        {
            foreach (var customer in _storage.Customers)
                GetCustomerInfoById(customer.Id);
        }
        public void GetCustomerInfoById(int customerId)
        {
            var message = default(string);
            var customer = _memoryCach.GetOrCreate(customerId, () => GetObjectById(customerId), out message);                      
            Speaker.Output(message + "Person Id - " + customer.Id.ToString() + " Name - " + customer.Name);         
        }
        private IPersonable GetObjectById(int customerId)
        {
            return _storage.Customers.FirstOrDefault(f => f.Id == customerId);
        }
    }
}
