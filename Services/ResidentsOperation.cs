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
        public ResidentsOperation(IResidentable samePersons, ILogger logger, DataStorage dateStorage)
        {
            _storage = samePersons;
            _logger = logger;
            _dateStorage = dateStorage;
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
        public bool GetCustomerInfo()
        {
            foreach (var customer in _storage.Customers)
                if (!GetCustomerInfoById(customer.Id))
                {
                    Speaker.Output("Output Error", "Error");
                    return false;
                }

            return true;
        }
        public bool GetCustomerInfoById(int customerId)
        {
            var customer = _storage.Customers.FirstOrDefault(f => f.Id == customerId); ;
            if (customer is null)           
                return false;
            
            Speaker.Output("Person Id - " + customer.Id.ToString() + " Name - " + customer.Name);
            return true;           
        }       
    }
}
