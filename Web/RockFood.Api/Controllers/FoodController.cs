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
        private readonly IFoodOperation _foodOperation;
        public FoodController(IFoodOperation context)
        {
            _foodOperation = context;
        }

        [HttpGet("GetAllFoods")]
        public IEnumerable<IFoodable> GetFood()
        {
            return _foodOperation.Get();
        }
        [HttpGet("GetFood")]
        public IFoodable GetFood(int id)
        {
            var food = _foodOperation.Get(id);
            return food;
        }

        [HttpPut("BuyFood")]
        public void BuyFood(int id, double number = 1)
        {
            _foodOperation.BuyFood(id, number);
            _foodOperation.Save();
        }

        [HttpPost("AddFood")]
        public void AddFood(Food food)
        {
            _foodOperation.Add(food);
            _foodOperation.Save();
        }

        [HttpDelete("DeleteFood")]
        public void DeleteFood(int id)
        {
            var food = _foodOperation.Get(id);
            if (food != default)
            {
                _foodOperation.Delete(id);
                _foodOperation.Save();
            }            
        }
    }
}
