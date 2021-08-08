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
            //AddPerson(new Person() { Name = "Sharlin" });
            GetPersons();
        }
        private static void AddPerson(Person person)
        {
            _context.Add(person);
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
