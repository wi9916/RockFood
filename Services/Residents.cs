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
        private readonly DataStorage _storageDate;
        public List<Customer> Customers { get; }      
        public Residents(DataStorage storageDate)
        {
            _storageDate = storageDate; 
            Customers = new List<Customer>();           

            if (!_storageDate.CheckStorageDataAvailability())
            {
                CreateNewResidents();
                _storageDate.SaveData(Customers);
            }                
            else
            {
                Customers = _storageDate.LoadData(Customers);
            }                                   
        }
        private void CreateNewResidents()
        {           
            Customers.Add(new Customer { Id = 1, Name = "Jon" });
            Customers.Add(new Customer { Id = 2, Name = "Petro" });
            Customers.Add(new Customer { Id = 3, Name = "Van" });
        }
        public void AddResident(Customer item)
        {
            item.Id = Customers.Max(f => f.Id) + 1;
            Customers.Add(item);
            _storageDate.SaveData(Customers);
        }
        public bool GetResident(Customer item)
        {
            var index = Customers.FindIndex(f => f.Id == item.Id);
            if (index == -1)
                return false;

            Customers[index] = item;
            _storageDate.SaveData(Customers);

            return true;
        }
        public Customer GetResidentById(int itemId)
        {
            return Customers.FirstOrDefault(f => f.Id == itemId);
        }
    }
}
