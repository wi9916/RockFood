using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Data
{
    public class CompanyRepository : IRepository<Company>
    {
        private DataContext _db;
        public CompanyRepository(DataContext context)
        {
            this._db = context;
        }
        public IEnumerable<Company> GetAll()
        {
            return _db.Companys;
        }
        public Company Get(int id)
        {
            return _db.Companys.Find(id);
        }
        public void Create(Company obj)
        {
            _db.Companys.Add(obj);
        }
        public void Update(Company obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Company obj = _db.Companys.Find(id);
            if (obj != null)
                _db.Companys.Remove(obj);
        }
    }   
}
