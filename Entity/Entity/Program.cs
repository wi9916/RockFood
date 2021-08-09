using Entity.Models;
using Entity.Repositories;
using Entity.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace Entity
{
    class Program
    {
        static void Main(string[] args)
        {
            TestMetodRepoContrib();
        }
        private static IConfiguration Initialize()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetings.json", optional: true, reloadOnChange: true);
            
            return builder.Build();
        }
        private static void TestMetodLinq()
        {
            //var SameShop = new VirtualShop();

            //    SameShop.GetAllProduct();            
            //    SameShop.GetAllProductWithCompany();
            //    SameShop.GetAllCategories();
            //    SameShop.GetAllCompany();
            //SameShop.GetProductFromCompany(1,2);
        }
        private static void TestMetodRepo()
        {            
            var config = Initialize();
            var repo = new Repo(config.GetConnectionString("DefaultConnection"));

            //var rez = repo.GetById(1);
            //Console.WriteLine($"{rez.Id}; {rez.Name}");

            //var rez = repo.GetByIdMulty(1);

            //Console.WriteLine($"{rez.Id}; {rez.Name}");
            //foreach (var r in rez.Products)
            //    Console.WriteLine($"{r.Id}; {r.Name}; {r.Price} ");

            //var rez = repo.GetAllMulty();
            //foreach (var r in rez)
            //{
            //    Console.WriteLine($"{r.Id}; {r.Name}");                
            //        foreach (var p in r.Products)
            //        {
            //            if (p is not null)
            //                Console.WriteLine($"{p.Id}; {p.Name}; {p.Price} ");
            //        }
            //}
        }
        private static void TestMetodRepoContrib()
        {
            var config = Initialize();
            var repo = new RepoContrib(config.GetConnectionString("DefaultConnection"));

            //{
            //    var rez = repo.GetById(1);
            //    Console.WriteLine($"{rez.Id}; {rez.Name}");
            //    foreach (var r in rez.Products)
            //        Console.WriteLine($"{r.Id}; {r.Name}; {r.Price} ");
            //}

            //{
            //    var MyCompanies = new List<Company>();
            //    var MyProducts = new List<Product>();
            //    MyCompanies.Add(new Company { Name = "Fast Cat" });
            //    MyCompanies.Add(new Company { Name = "Gold Fish" });
            //    MyCompanies.Add(new Company { Name = "Big Sun" });

            //    MyProducts.Add(new Product { Name = "The Best Cakes", CompanyId = 1 });
            //    MyProducts.Add(new Product { Name = "Same Cake", CompanyId = 1 });
            //    MyProducts.Add(new Product { Name = "Streng Cakes", CompanyId = 1 });
            //    MyProducts.Add(new Product { Name = "Orang Pie", CompanyId = 2 });
            //    MyProducts.Add(new Product { Name = "Aple Pie", CompanyId = 2 });
            //    MyProducts.Add(new Product { Name = "Special Cakes", CompanyId = 3 });
            //    MyProducts.Add(new Product { Name = "Syper Cakes", CompanyId = 3 });

            //    foreach (var p in MyProducts)
            //    {
            //        MyCompanies[p.CompanyId - 1].Products.Add(p);
            //    }

            //    foreach (var p in MyCompanies)
            //        repo.Add(p);
            //}

            //{
            //    var companys = repo.GetAll();
            //    foreach (var c in companys)
            //    {
            //        Console.WriteLine();
            //        Console.WriteLine($"{c.Name} id: {c.Id}");
            //        Console.WriteLine("++++++++++++++++++++++++++++");
            //        foreach (var p in c.Products)
            //            Console.WriteLine($"{p.Name} id: {p.Id}");
            //    }

            //    repo.Delate(companys[0]);
            //}
            //{
            //    var companys = repo.GetAll();
            //    foreach (var c in companys)
            //    {
            //        c.About = "Update Companys";
            //        foreach (var p in c.Products)
            //            p.About = "Update Products";
            //        repo.Update(c);
            //    }
            //}
        }
    }
}
