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
        private readonly IFoodService _foodService;
        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet("GetAllFoods")]
        public IEnumerable<IFoodable> GetAllFoods()
        {
            return _foodService.Get();
        }
        [HttpGet]
        public IFoodable GetFood(int id)
        {
            var food = _foodService.Get(id);
            return food;
        }

        [HttpPut]
        public void BuyFood(int id, double number = 1)
        {
            _foodService.BuyFood(id, number);
            _foodService.Save();
        }

        [HttpPost]
        public void AddFood(Food food)
        {
            _foodService.Add(food);
            _foodService.Save();
        }

        [HttpDelete]
        public void DeleteFood(int id)
        {
            var food = _foodService.Get(id);
            if (food != default)
            {
                _foodService.Delete(id);
                _foodService.Save();
            }            
        }
    }
}
