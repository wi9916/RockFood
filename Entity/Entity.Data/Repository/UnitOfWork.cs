using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Data.Repository
{
    public class UnitOfWork : IDisposable
    {
        private DataContext _db = new DataContext();
        private CustomerRepository _customerRepository;
        private PersonRepository _personRepository;

        public CustomerRepository Customers
        {
            get
            {
                if (_customerRepository == null)
                    _customerRepository = new CustomerRepository(_db);
                return _customerRepository;
            }
        }

        public PersonRepository Persons
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
