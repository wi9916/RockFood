using RockFood.Interfaces;
using RockFood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood
{
    public class Residents: IResidentable
    {
        public List<Customer> Customers { get; }
        public Residents()
        {
            string fileSerializer = "customers";
            var ser = new Serializer();
            Customers = new List<Customer>();

            if (ser.CheckFile(fileSerializer))
            {
                Customers = ser.Desialization(Customers, fileSerializer);
            }
            else
            {
                CreateNewResidents();
                ser.Serialization(Customers, fileSerializer);
            }
        }
        private void CreateNewResidents()
        {           
            Customers.Add(new Customer { Id = 1, Name = "Jon" });
            Customers.Add(new Customer { Id = 2, Name = "Petro" });
            Customers.Add(new Customer { Id = 3, Name = "Van" });
        }     
    }
}
