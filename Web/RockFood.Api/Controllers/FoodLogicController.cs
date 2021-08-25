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
    [Route("api/FoodLogicController")]
    [ApiController]
    public class FoodLogicController : ControllerBase
    {
        private readonly IFoodOperation _context;

        public FoodLogicController(IFoodOperation context)
        {
            _context = context;
        }

        [HttpGet("GetFoods")]
        public async Task<IEnumerable<string>> GetFoodAsync()
        {
            return await _context.GetAsync();
        }
        [HttpGet("GetFood")]
        public async Task<ActionResult<string>> GetFoodAsync(int id)
        {
            var food = _context.GetAsync(id);
            return await food;
        }

        [HttpPut("BuyFood")]
        public ActionResult<string> PutFood(int id,double number = 1)
        {
            _context.BuyFood(id, number);          
            _context.Save();
            return NoContent();
        }

        [HttpPost("AddFood")]
        public ActionResult<string> AddFood(Food food)
        {
            _context.Add(food);
            _context.Save();

            return CreatedAtAction("GetFood", new { id = food.Id }, food);
        }

        [HttpDelete("DeleteFood")]
        public ActionResult<string> DeleteFood(int id)
        {
            var food = _context.GetAsync(id);
            if (food == default)
            {
                return "Not Found";
            }

            _context.Delete(id);
            _context.Save();
            return "Delate";
        }
    }
}
