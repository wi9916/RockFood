using Entity.Data;
using Entity.Models;
using System;
using System.Linq;

namespace EntityTest
{
    class Program
    {
        public static DataContext _context;
        static void Main(string[] args)
        {
            _context = new DataContext();
            _context.Database.EnsureCreated();
            //Add(new Person() {Name = "Vilamina" });
            GetPersons();
        }
        private static void Add<t>(t obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        private static void GetPersons()
        {
            var people = _context.Persons.ToList();
            foreach(var p in people)
            {
                Console.WriteLine($"Id:{p.Id} Name:{p.Name}");
            }
        }
    }
}
