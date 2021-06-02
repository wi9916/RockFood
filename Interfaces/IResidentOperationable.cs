using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Interfaces
{
    public interface IResidentOperationable
    {
        bool CreateCustomer(Customer person);
        bool GetCustomerInfo();
        bool GetCustomerInfoById(int customerId);
    }
}
