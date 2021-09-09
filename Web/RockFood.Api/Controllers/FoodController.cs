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
        private readonly IFoodService _foodOperation;
        public FoodController(IFoodService foodOperation)
        {
            _foodOperation = foodOperation;
        }

        [HttpGet("GetAllFoods")]
        public IEnumerable<IFoodable> GetAllFoods()
        {
            return _foodOperation.Get();
        }

        [HttpGet]
        public IFoodable GetFood(int id)
        {
            throw new ArgumentNullException();
            var food = _foodOperation.Get(id);
            return food;
        }

        [HttpPut]
        [ServiceFilter(typeof(BuyFoodActionFilter))]
        public IActionResult BuyFood(int id, double number = 1)
        {
            if(_foodOperation.Get(id) is null)
                return NotFound();

            _foodOperation.BuyFood(id, number);
            _foodOperation.Save();
            return Ok();
        }      

        [HttpPost]
        public IActionResult AddFood(Food food)
        {
            _foodOperation.Add(food);
            _foodOperation.Save();
            return Ok();
        }

        [HttpDelete]
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
