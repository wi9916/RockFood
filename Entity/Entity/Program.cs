using Entity.Services;
using System;

namespace Entity
{
    class Program
    {
        static void Main(string[] args)
        {
            var SameShop = new VirtualShop();

            //    SameShop.GetAllProduct();            
            //    SameShop.GetAllProductWithCompany();
            //    SameShop.GetAllCategories();
            //    SameShop.GetAllCompany();
            SameShop.GetProductFromCompany(1,2);
        }
    }
}
