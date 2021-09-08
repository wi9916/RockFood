using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Data
{
    public class ProductRepository : IRepository<Product>
    {
        private DataContext _db;
        public ProductRepository(DataContext context)
        {
            this._db = context;
        }
        public IEnumerable<Product> GetAll()
        {
            return _db.Products;
        }
        public Product Get(int id)
        {
            return _db.Products.Find(id);
        }
        public void Create(Product obj)
        {
            _db.Products.Add(obj);
        }
        public void Update(Product obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Product obj = _db.Products.Find(id);
            if (obj != null)
                _db.Products.Remove(obj);
        }
    }   
}
