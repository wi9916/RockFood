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
        bool AddCustomer(Customer person);
        void OutputCustomerInfo();
        void OutputCustomerInfoById(int customerId);
    }
}
