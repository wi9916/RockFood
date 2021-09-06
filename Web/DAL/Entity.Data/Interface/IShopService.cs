using Entity.Data.Repository;
using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Data.Interface
{
    public interface IShopService : IDisposable
    {
        public IRepository<Customer> Customers { get; }
        public IRepository<Food> Foods { get; }
        public void Save();      
    }
}
