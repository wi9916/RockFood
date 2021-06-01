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
        private readonly MemoryCache<IPersonable> _memoryCach;
        public ResidentsOperation(IResidentable samePersons, ILogger logger, MemoryCache<IPersonable> memoryCach)
        {            
            _storage = samePersons;
            _logger = logger;
            _memoryCach = memoryCach;
        }
        public bool CreateNewCustomer(Customer person)
        {
            if (_storage.Customers is null)
                return false;

            var message = " Create new customer Name: " + person.Name;
            
            person.Id = _storage.Customers.Max(f => f.Id) + 1;
            _storage.Customers.Add(person);
            Speaker.Output(message, "Create");
            _logger.Log(base.GetType() + message);
            return true;          
        }
        public void OutputInfoAboutCustomer()
        {
            foreach (var customer in _storage.Customers)
                Task.Run( ()=>OutputInfoAboutCustomer(customer.Id) );                               
        }
        public void OutputInfoAboutCustomer(int customerId)
        {
            var message = default(string);
            var customer = _memoryCach.GetOrCreate(customerId, () => _storage.GetObject(customerId),out message);
            Speaker.Output(message + "Person Id - " + customer.Id.ToString() + " Name - " + customer.Name);        
        }         
    }
}
