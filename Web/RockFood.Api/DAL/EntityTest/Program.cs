using Entity.Data;
using Entity.Data.Repository;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityTest
{
    class Program
    {
        private static UnitOfWork _unitOfWork;
        static void Main(string[] args)
        {            
            _unitOfWork = new UnitOfWork();
            Add();
            GetPersons();
        }
        private static void Add()
        {
            var person = new Person()
            {
                Name = "Leonid",
                About = "UnitOfWork Add"
            };

            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer() { Discount = 22 });
            customers.Add(new Customer() { Discount = 23 });
            customers.Add(new Customer() { Discount = 24 });
            customers.Add(new Customer() { Discount = 25 });
            person.Customers = customers;

            _unitOfWork.Persons.Create(person);
            _unitOfWork.Save();
        }
        private static void GetPersons()
        {
            var people = _unitOfWork.Persons.GetAll();
            foreach (var p in people)
            {
                Console.WriteLine($"Id:{p.Id} Name:{p.Name} Letter:{p.NameLetterCount}");
            }
        }
    }
}
