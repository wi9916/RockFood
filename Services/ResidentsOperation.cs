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
        private readonly IResidentable storage;
        public ResidentsOperation()
        {
            storage = new Residents();
        }
        public ResidentsOperation(IResidentable samePersons)
        {
            storage = samePersons;
        }
        public bool CreateNewCustomer(IPersonable person)
        {
            if (storage.Customers is not null)
            {
                person.Id = storage.Customers.Count();
                storage.Customers.Add(person);
                Speaker.Output("new Customer => " + person.Name, "Create");
                return true;
            }
            return false;
        }
        public bool OutputInfoAboutCustomer()
        {
            foreach (var customer in storage.Customers)
                if (!OutputInfoAboutCustomer(customer.Id))
                {
                    Speaker.Output("Output Error", "Error");
                    return false;
                }

            return true;
        }
        public bool OutputInfoAboutCustomer(int customerId)
        {
            var index = storage.Customers.FindIndex(f => f.Id == customerId);
            if (index >= 0)
            {
                Speaker.Output("Person Id - " + storage.Customers[index].Id.ToString() + " Name - " + storage.Customers[index].Name);
                return true;
            }
            return false;
        }       
    }
}
