using Dapper;
using Dapper.Contrib.Extensions;
using Entity.Interfaces;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repositories
{
    public class RepoContrib
    {
        private IDbConnection db;
        public RepoContrib(string connectionString)
        {
            db = new SqlConnection(connectionString);
        }
        public void Add(Company obj)
        {
            db.Insert(obj);
            if (obj.Products.Count() > 0)
            {
                foreach (var p in obj.Products)
                {
                    p.CompanyId = obj.Id;
                    Add(p);
                }
            }
        }
        public void Add(Product obj)
        {
            db.Insert(obj);
        }
        public void Delate(Company obj)
        {
            db.Delete(obj);
            if (obj.Products.Count() > 0)
            {
                foreach (var p in obj.Products)
                    Delate(p);
            }
        }
        public void Delate(Product obj)
        {
            db.Delete(obj);
        }
        public List<Company> GetAll()
        {
            var rez = db.GetAll<Company>().ToList();
            var products = db.GetAll<Product>().ToList();
            foreach (var p in products)
            {
                foreach (var c in rez)
                {
                    if (c.Id == p.CompanyId)
                        c.Products.Add(p);
                }
            }
            return rez;
        }
        public Company GetById(int id)
        {

            var rez = db.Get<Company>(id);
            if (rez is null)
                return new Company();

            return rez;
        }
        public Company GetByIdMulty(int id)
        {
            var rez = db.Get<Company>(id);
            var prod = db.GetAll<Product>();
            if (rez is null)
                return new Company();

            rez.Products = prod.Where(e => e.CompanyId == id).ToList();
            return rez;
        }
        public void Update(Company obj)
        {
            db.Update(obj);
            if (obj.Products.Count() > 0)
            {
                foreach (var p in obj.Products)
                    Update(p);
            }
        }
        public void Update(Product obj)
        {
            db.Update(obj);
        }
    }
}
