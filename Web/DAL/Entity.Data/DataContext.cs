using Entity.Data.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RockFood.Interfaces;
using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Data
{
    public class DataContext: DbContext, IDataContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Customer> Customers { get; set; }
        
        public DataContext(DbContextOptions<DataContext> options)
        : base(options){}
    }
}
