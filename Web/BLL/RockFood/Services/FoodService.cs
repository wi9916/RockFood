using Entity.Data;
using Entity.Data.Interface;
using Microsoft.EntityFrameworkCore;
using RockFood.Interfaces;
using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Services
{
    public class FoodService : IFoodService
    {
        private readonly DataContext _db;
        private readonly IMemoryCacheable<IFoodable> _memoryCache;
        public FoodService(DataContext dataContext, IMemoryCacheable<IFoodable> memoryCache)
        {
            _db = dataContext;
            _memoryCache = memoryCache;
        }

        public string Add(Food food)
        {
            _db.Foods.Add(food);

            var message = " Put new food Name: " + food.Name + ", Count: "
                + food.Count + ", Price: " + food.Price;

            return message;
        }

        public string BuyFood(int foodId, double number = 1)
        {
            var food = _db.Foods.Find(foodId);
            if (food is null)
                return "Error";

            if (food.Count - number < 1)
                number = food.Count;

            var message = " Bought food Name: " + food.Name + ", Take: " + number +
                " / " + food.Count + ", For price: " + food.Price;

            food.Count -= number;
            _db.Entry(food).State = EntityState.Modified;
            return message;
        }

        public List<IFoodable> Get()
        {
            var foods = new List<IFoodable>();
            foreach (var food in _db.Foods)
                foods.Add(Get(food.Id));

            return foods;
        }

        public IFoodable Get(int id)
        {
            var message = default(string);
            var food = _memoryCache.GetOrCreate(id, () => _db.Foods.Find(id), out message);
            return food;
        }

        public void Edit(Food food)
        {
            var baseFood = _db.Foods.Find(food.Id);
            baseFood.Name = food.Name;
            baseFood.About = food.About;
            baseFood.Count = food.Count;
            baseFood.Price = food.Price;
            _db.Entry(baseFood).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Food food = _db.Foods.Find(id);
            if (food != null)
                _db.Foods.Remove(food);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
