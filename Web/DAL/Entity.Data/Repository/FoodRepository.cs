using Microsoft.EntityFrameworkCore;
using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Data.Repository
{
    public class FoodRepository : IRepository<Food>
    {
        private DataContext _db;
        public FoodRepository(DataContext context)
        {
            _db = context;
        }
        public IEnumerable<Food> GetAll()
        {
            return _db.Foods;
        }
        public Food Get(int id)
        {
            return _db.Foods.Find(id);
        }
        public void Create(Food food)
        {
            _db.Foods.Add(food);
        }
        public void Update(Food food)
        {
            _db.Entry(food).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Food food = _db.Foods.Find(id);
            if (food != null)
                _db.Foods.Remove(food);
        }
    }
}
