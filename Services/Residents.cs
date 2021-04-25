using RockFood.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood
{
    public class Residents: IResidents
    {
        public List<Customer> Customers { get; set; }
        public Residents()
        {          
            Customers = new List<Customer>();
            CreateNewResidents();
        }
        public bool CreateNewResidents()
        {           
            Customers.Add(new Customer { Id = 0, Name = "Jon" });
            Customers.Add(new Customer { Id = 1, Name = "Petro" });
            return true;
        }
        public bool CreateNewCustomer(string name)
        {          
            if (Customers is not null)
            {
                var id = Customers.Count();
                Customers.Add(new Customer { Id = id, Name = name });
                Speaker.Output("new Customer => " + name, "Create");
                return true;
            }
            return false;
        }
        public bool OutputInfoAboutCustomer(int customerId)
        {
            try                      // try/catch only for examle
            {
                var index = Customers.FindIndex(f => f.Id == customerId);
                if (index >= 0)
                {
                    Speaker.Output("Id - " + Customers[index].Id.ToString() + " Name - " + Customers[index].Name);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Allarm", ex);
            }          
            return false;
        }
    }
}
