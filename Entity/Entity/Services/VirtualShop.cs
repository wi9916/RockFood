using Entity.Interfaces;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Services
{
    public class VirtualShop
    {
        public List<IProductable> MyProducts { get; set; }
        public List<ICompanable> MyCompanies { get; set; }
        public List<ICategoriesable> MyCategories { get; set; }
        public List<IProductsFromCompanable> MyProductsFromCompanies { get; set; }

        public VirtualShop()
        {
            MyProducts = new List<IProductable>();
            MyCompanies = new List<ICompanable>();
            MyCategories = new List<ICategoriesable>();
            MyProductsFromCompanies = new List<IProductsFromCompanable>();
            StartValue();
        }
        private void StartValue()
        {
            MyCategories.Add(new Categories { Id = 1, Name = "Cakes" });
            MyCategories.Add(new Categories { Id = 2, Name = "Pie" });

            MyCompanies.Add(new Company { Id = 1, Name = "Fast Cat" });
            MyCompanies.Add(new Company { Id = 2, Name = "Gold Fish" });
            MyCompanies.Add(new Company { Id = 3, Name = "Big Sun" });

            MyProducts.Add(new Product { Id = 1, Name = "The Best Cakes", CategoryId = 1 });
            MyProducts.Add(new Product { Id = 2, Name = "Same Cake", CategoryId = 1 });
            MyProducts.Add(new Product { Id = 3, Name = "Orang Pie", CategoryId = 2 });
            MyProducts.Add(new Product { Id = 4, Name = "Aple Pie", CategoryId = 2 });
            MyProducts.Add(new Product { Id = 5, Name = "Streng Cakes", CategoryId = 1 });
            MyProducts.Add(new Product { Id = 6, Name = "Special Cakes", CategoryId = 1 });
            MyProducts.Add(new Product { Id = 7, Name = "Syper Cakes", CategoryId = 1 });

            MyProductsFromCompanies.Add(new ProductsFromCompany { CompanyId = 1, ProductId = 1 });
            MyProductsFromCompanies.Add(new ProductsFromCompany { CompanyId = 1, ProductId = 2 });
            MyProductsFromCompanies.Add(new ProductsFromCompany { CompanyId = 1, ProductId = 3 });
            MyProductsFromCompanies.Add(new ProductsFromCompany { CompanyId = 1, ProductId = 4 });
            MyProductsFromCompanies.Add(new ProductsFromCompany { CompanyId = 1, ProductId = 5 });
            MyProductsFromCompanies.Add(new ProductsFromCompany { CompanyId = 2, ProductId = 1 });
            MyProductsFromCompanies.Add(new ProductsFromCompany { CompanyId = 2, ProductId = 2 });
            MyProductsFromCompanies.Add(new ProductsFromCompany { CompanyId = 2, ProductId = 6 });
            MyProductsFromCompanies.Add(new ProductsFromCompany { CompanyId = 3, ProductId = 7 });
        }
        public void GetAllProduct()
        {
            Speaker.Output("===========================================================================");
            Speaker.Output("All Product");

            //var products = from e in MyProduct
            //               orderby e.Name
            //               select e;

            var products = MyProducts.Select(e => e).OrderBy(e => e.Name);

            foreach (var p in products)
            {
                Speaker.Output("Name - " + p.Name);
            }
        }
        public void GetAllProductWithCompany()
        {
            Speaker.Output("===========================================================================");
            Speaker.Output("Product with Company");

            var products = from company in MyCompanies
                           join prodComp in MyProductsFromCompanies on company.Id equals prodComp.CompanyId
                           join product in MyProducts on prodComp.ProductId equals product.Id
                           select new { CompanyName = company.Name, ProductName = product.Name };

            foreach (var p in products)
            {
                Speaker.Output(p.CompanyName + " make - " + p.ProductName);
            }
        }
        public void GetAllCategories()
        {
            Speaker.Output("===========================================================================");
            Speaker.Output("Categories");

            var products = MyCategories.GroupJoin(
                        MyProducts,
                        c => c.Id,
                        p => p.CategoryId,
                        (categor, prod) => new
                        {
                            Name = categor.Name,
                            Count = prod.Count()
                        });
            foreach (var p in products)
            {
                Speaker.Output("Name - " + p.Name + "; Count - " + p.Count);
            }
        }
        public void GetAllCompany()
        {
            Speaker.Output("===========================================================================");
            Speaker.Output("Company");

            var products = MyCompanies.GroupJoin(
                        MyProductsFromCompanies,
                        c => c.Id,
                        p => p.CompanyId,
                        (company, prod) => new
                        {
                            Name = company.Name,
                            Count = prod.Count()
                        }).OrderByDescending(p => p.Count);

            foreach (var p in products)
            {
                Speaker.Output("Company - " + p.Name + "; Count - " + p.Count);
            }
        }

        public void GetProductFromCompany(int IdCompany1, int IdCompany2)
        {
            Speaker.Output("===========================================================================");
            Speaker.Output("General products in Companies");

            var company1 = from company in MyCompanies
                           join prodComp in MyProductsFromCompanies on company.Id equals prodComp.CompanyId
                           join product in MyProducts on prodComp.ProductId equals product.Id
                           where company.Id == IdCompany1
                           select product.Name;

            var company2 = from company in MyCompanies
                           join prodComp in MyProductsFromCompanies on company.Id equals prodComp.CompanyId
                           join product in MyProducts on prodComp.ProductId equals product.Id
                           where company.Id == IdCompany2
                           select product.Name;

            var general = company1.Intersect(company2);

            foreach (var p in general)
            {
                Speaker.Output(" ProductName - " + p);
            }

            Speaker.Output("===========================================================================");
            Speaker.Output("Exclusive products in the " + MyCompanies.FirstOrDefault(p=>p.Id == IdCompany1).Name);

            general = company1.Except(company2);

            foreach (var p in general)
            {
                Speaker.Output(" ProductName - " + p);
            }

            Speaker.Output("===========================================================================");
            Speaker.Output("Exclusive products in the " + MyCompanies.FirstOrDefault(p => p.Id == IdCompany2).Name);

            general = company2.Except(company1);

            foreach (var p in general)
            {
                Speaker.Output(" ProductName - " + p);
            }
        }
    }
}
