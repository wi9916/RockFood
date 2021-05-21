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
            var ser = new Serializer("customers");
            Customers = new List<Customer>();

            if (ser.CheckFile())
            {
                Customers = ser.Desialization(Customers);
            }
            else
            {
                CreateNewResidents();
                ser.Serialization(Customers);
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
