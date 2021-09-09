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
        private readonly IFoodServices _foodServices;
        public FoodController(IFoodServices foodServices)
        {
            _foodServices = foodServices;
        }

        [HttpGet]
        public IEnumerable<IFoodable> GetAllFoods()
        {
            return _foodServices.Get();
        }
        [HttpGet]
        public IFoodable GetFood(int id)
        {
            var food = _foodServices.Get(id);
            return food;
        }

        [HttpPut]
        public IActionResult BuyFood(int id, double number = 1)
        {
            if(_foodServices.Get(id) is null)
                return NotFound();

            _foodServices.BuyFood(id, number);
            _foodServices.Save();
            return Ok();
        }

        [HttpPost]
        public IActionResult AddFood(Food food)
        {
            _foodServices.Add(food);
            _foodServices.Save();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteFood(int id)
        {
            var food = _foodServices.Get(id);
            if (food != default)
            {
                _foodServices.Delete(id);
                _foodServices.Save();
                return Ok();
            }
            return NotFound();
        }
    }
}
