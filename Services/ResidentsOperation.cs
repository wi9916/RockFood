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
        public ResidentsOperation(IResidentable samePersons, ILogger logger)
        {
            _storage = samePersons;
            _logger = logger;
        }
        public bool CreateNewCustomer(IPersonable person)
        {
            if (_storage.Customers is null)
                return false;

            var message = " Create new customer Name: " + person.Name;
            
            person.Id = _storage.Customers.Max(f => f.Id) + 1;
            _storage.Customers.Add(person);
            Speaker.Output(message, "Create");
            _logger.Log(base.GetType() + message, MessageTypes.Information);
            return true;          
        }
        public bool OutputInfoAboutCustomer()
        {
            foreach (var customer in _storage.Customers)
                if (!OutputInfoAboutCustomer(customer.Id))
                {
                    Speaker.Output("Output Error", "Error");
                    return false;
                }

            return true;
        }
        public bool OutputInfoAboutCustomer(int customerId)
        {
            var customer = _storage.Customers.FirstOrDefault(f => f.Id == customerId);
            if (customer is null)           
                return false;
            
            Speaker.Output("Person Id - " + customer.Id.ToString() + " Name - " + customer.Name);
            return true;           
        }       
    }
}
