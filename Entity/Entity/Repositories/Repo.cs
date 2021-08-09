using Dapper;
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
    public class Repo : IRepoeble
    {
        private IDbConnection db;
        public Repo(string connectionString)
        {
            db = new SqlConnection(connectionString);
        }
        public void Add(ICompanable obj)
        {
            throw new NotImplementedException();
        }

        public void Delate(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Company> GetAll()
        {
            var sql = "Select * from Company";
            var rez = db.Query<Company>(sql).ToList();
            if (rez is null)
                return new List<Company>();

            return rez;
        }
        public List<Company> GetAllMulty()
        {
            var dictionary = new Dictionary<int, Company>();
            var sql = "Select * from Company Left Join Product On Product.CompanyId = Company.Id";
            var rez = db.Query<Company, Product, Company>(sql,
                (company, product) =>
                {
                    Company com;
                    if (!dictionary.TryGetValue(company.Id, out com))
                    {
                        com = company;
                        com.Products = new List<Product>();
                        dictionary.Add(com.Id, com);
                    }
                    com.Products.Add(product);
                    return com;
                },                
                splitOn: "Id")
                .Distinct()
                .ToList();
            if (rez is null)
                return new List<Company>();

            return rez;
        }
        public ICompanable GetById(int id)
        {
            var sql = "Select * from Company where Id = @Id";
            var rez = db.Query<Company>(sql, new { Id = id }).FirstOrDefault();
            if (rez is null)
                return new Company();

            return rez;
        }
        public Company GetByIdMulty(int id)
        {
            var dictionary = new Dictionary<int, Company>();
            var sql = "Select * from Company Left Join Product On Product.CompanyId = Company.Id Where Company.Id = @Id";
            var rez = db.Query<Company,Product,Company>(sql,
                (company, product) =>
                {
                    Company com;
                    if(!dictionary.TryGetValue(company.Id,out com))
                    {
                        com = company;
                        com.Products = new List<Product>();
                        dictionary.Add(com.Id, com);
                    }
                    com.Products.Add(product);
                    return com;
                },
                param: new { Id = id },
                splitOn:"Id")
                .Distinct()
                .ToList()
                .FirstOrDefault();

            if (rez is null)
                return new Company();

            return rez;
        }
        public void Update(ICompanable obj)
        {
            throw new NotImplementedException();
        }
    }
}
