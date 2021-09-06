using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RockFood.Interfaces;
using RockFood.Models;
using RockFood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockFood.Api.Controllers
{
    [Route("api/Food")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodOperation _context;
        public FoodController(IFoodOperation context)
        {
            _context = context;
        }

        [HttpGet("GetAllFoods")]
        public IEnumerable<IFoodable> GetFood()
        {
            return _context.Get();
        }
        [HttpGet("GetFood")]
        public IFoodable GetFood(int id)
        {
            var food = _context.Get(id);
            return food;
        }

        [HttpPut("BuyFood")]
        public void BuyFood(int id, double number = 1)
        {
            _context.BuyFood(id, number);
            _context.Save();
        }

        [HttpPost("AddFood")]
        public void AddFood(Food food)
        {
            _context.Add(food);
            _context.Save();
        }

        [HttpDelete("DeleteFood")]
        public void DeleteFood(int id)
        {
            var food = _context.Get(id);
            if (food != default)
            {
                _context.Delete(id);
                _context.Save();
            }

            
        }
    }
}
