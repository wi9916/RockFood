using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Data.Repository
{
    public class UnitOfWork : IDisposable
    {
        private readonly DataContext _db = new DataContext();
        private IRepository<Customer> _customerRepository;
        private IRepository<Person> _personRepository;

        public IRepository<Customer> Customers
        {
            get
            {
                if (_customerRepository == null)
                    _customerRepository = new CustomerRepository(_db);
                return _customerRepository;
            }
        }

        public IRepository<Person> Persons
        {
            get
            {
                if (_personRepository == null)
                    _personRepository = new PersonRepository(_db);
                return _personRepository;
            }
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
