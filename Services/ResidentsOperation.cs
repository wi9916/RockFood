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
        public bool AddCustomer(Customer person)
        {
            if (_storage.Customers is null)
                return false;

            _storage.AddItem(person);

            var message = " Create new customer Name: " + person.Name;            
            Speaker.Output(message, "Create");
            _logger.Log(base.GetType() + message);

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
            var customer = _storage.GetItemById(customerId);
            if (customer is null)           
                return false;
            
            Speaker.Output("Person Id - " + customer.Id.ToString() + " Name - " + customer.Name);
            return true;           
        }       
    }
}
