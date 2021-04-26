using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Interfaces
{
    public interface ICustomerable
    {
        List<Customer> Customers { get; set; }
        bool CreateNewCustomer(string name);
        bool OutputInfoAboutCustomer(int customerId);      
    }
}
