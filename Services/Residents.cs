using RockFood.Interfaces;
using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Services
{
    public class Residents: IResidentable
    {
        private readonly SerializeStorage _serializeStorage;
        public List<Customer> Customers { get; }      
        public Residents(SerializeStorage serializeStorage)
        {
            _serializeStorage = serializeStorage; 
            Customers = new List<Customer>();           
            CreateNewResidents();

            if (!_serializeStorage.Serialize(Customers))
                Customers = _serializeStorage.Desialize(Customers);
        }
        private void CreateNewResidents()
        {           
            Customers.Add(new Customer { Id = 1, Name = "Jon" });
            Customers.Add(new Customer { Id = 2, Name = "Petro" });
            Customers.Add(new Customer { Id = 3, Name = "Van" });
        }     
    }
}
