﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Interfaces
{
    public interface IDialogable
    {     
        void DialogStartWorking();
        void DialogPutNewFood();
        void DialogCreateNewCustomer();
        void DialogChooseCustomer();
        void DialogChooseProduct(int customerId);
        bool DialogBuyProduct(int customerId, int foodId);       
    }
}