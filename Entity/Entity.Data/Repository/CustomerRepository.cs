using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Data.Repository
{    
    public class CustomerRepository : IRepository<Customer>
    {
        private DataContext _db;
        public CustomerRepository(DataContext context)
        {
            this._db = context;
        }
        public IEnumerable<Customer> GetAll()
        {
            return _db.Customers;
        }
        public Customer Get(int id)
        {
            return _db.Customers.Find(id);
        }
        public void Create(Customer customer)
        {
            _db.Customers.Add(customer);
        }
        public void Update(Customer customer)
        {
            _db.Entry(customer).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Customer cus = _db.Customers.Find(id);
            if (cus != null)
                _db.Customers.Remove(cus);
        }
    }
}
