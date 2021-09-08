using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RockFood.Api.Filter;
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
            //throw new ArgumentNullException();
            var food = _foodOperation.Get(id);
            return food;
        }

        [HttpPut("BuyFood")]
        [ServiceFilter(typeof(BuyFoodActionFilter))]
        public IActionResult BuyFood(int id, double number = 1)
        {
            if(_foodOperation.Get(id) is null)
                return NotFound();

            _foodOperation.BuyFood(id, number);
            _foodOperation.Save();
            return Ok();
        }

        [HttpPost("AddFood")]
        public IActionResult AddFood(Food food)
        {
            _foodOperation.Add(food);
            _foodOperation.Save();
            return Ok();
        }

        [HttpDelete("DeleteFood")]
        public IActionResult DeleteFood(int id)
        {
            var food = _foodOperation.Get(id);
            if (food != default)
            {
                _foodOperation.Delete(id);
                _foodOperation.Save();
                return Ok();
            }
            return NotFound();
        }
    }
}
