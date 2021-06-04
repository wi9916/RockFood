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

            if (!_serializeStorage.CheckFileAvailability())
            {
                CreateNewResidents();
                _serializeStorage.WriteFileSerialize(Customers);
            }                
            else
            {
                Customers = _serializeStorage.ReadFileSerialize(Customers);
            }                                   
        }
        private void CreateNewResidents()
        {           
            Customers.Add(new Customer { Id = 1, Name = "Jon" });
            Customers.Add(new Customer { Id = 2, Name = "Petro" });
            Customers.Add(new Customer { Id = 3, Name = "Van" });
        }
        public void AddItem(Customer item)
        {
            item.Id = Customers.Max(f => f.Id) + 1;
            Customers.Add(item);
            _serializeStorage.WriteFileSerialize(Customers);
        }
        public bool GetItem(Customer item)
        {
            var index = Customers.FindIndex(f => f.Id == item.Id);
            if (index == -1)
                return false;

            Customers[index] = item;
            _serializeStorage.WriteFileSerialize(Customers);

            return true;
        }
        public Customer GetCustomerById(int itemId)
        {
            return Customers.FirstOrDefault(f => f.Id == itemId);
        }
    }
}
