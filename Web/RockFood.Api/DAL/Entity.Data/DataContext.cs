using Microsoft.EntityFrameworkCore;
using RockFood.Interfaces;
using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source=DESKTOP-4H5PP4L; Integrated Security = true; Initial Catalog = WebRockFood");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Person>()
            //    .HasMany(p => p.Customers)
            //    .WithOne(c => c.Person);
        }
    }
}
