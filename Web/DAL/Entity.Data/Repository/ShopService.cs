﻿using Entity.Data.Interface;
using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Data.Repository
{
    public class ShopService : IDisposable, IShopService
    {
        private DataContext _db = new DataContext();
        private IRepository<Customer> _customerRepository;
        private IRepository<Food> _foodRepository;

        public IRepository<Customer> Customers
        {
            get
            {
                if (_customerRepository == null)
                    _customerRepository = new CustomerRepository(_db);
                return _customerRepository;
            }
        }

        public IRepository<Food> Foods
        {
            get
            {
                if (_foodRepository == null)
                    _foodRepository = new FoodRepository(_db);
                return _foodRepository;
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