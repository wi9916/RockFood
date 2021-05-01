﻿using RockFood.Interfaces;
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
        public ResidentsOperation(IResidentable samePersons)
        {
            storage = samePersons;
        }
        public bool CreateNewCustomer(IPersonable person)
        {
            if (storage.Customers is null)
                return false;

            person.Id = storage.Customers.Max(f => f.Id) + 1;
            storage.Customers.Add(person);
            Speaker.Output("new Customer => " + person.Name, "Create");
            return true;          
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
            var customer = storage.Customers.FirstOrDefault(f => f.Id == customerId);
            if (customer is null)           
                return false;
            
            Speaker.Output("Person Id - " + customer.Id.ToString() + " Name - " + customer.Name);
            return true;           
        }       
    }
}