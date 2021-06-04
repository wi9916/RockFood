using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Interfaces
{
    public interface IResidentable
    {
        List<Customer> Customers { get;}
        void AddItem(Customer item);
        bool GetItem(Customer item);
        Customer GetCustomerById(int itemId);
    }
}
