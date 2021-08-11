using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Data
{
    public class PersonRepository : IRepository<Person>
    {
        private DataContext _db;
        public PersonRepository(DataContext context)
        {
            _db = context;
        }
        public IEnumerable<Person> GetAll()
        {
            return _db.Persons;
        }
        public Person Get(int id)
        {
            return _db.Persons.Find(id);
        }

        public void Create(Person person)
        {
            _db.Persons.Add(person);
        }

        public void Update(Person person)
        {
            _db.Entry(person).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Person person = _db.Persons.Find(id);
            if (person != null)
                _db.Persons.Remove(person);
        }
    }   
}
