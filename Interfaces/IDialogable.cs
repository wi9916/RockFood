using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Interfaces
{
    public interface IDialogable
    {
        Task DialogStartWorkingAsync();
        void DialogPutNewFood();
        void DialogCreateNewCustomer();
        Task DialogChooseCustomerAsync();
        Task DialogChooseProductAsync(int customerId);
        bool DialogBuyProduct(int customerId, int foodId);       
    }
}
