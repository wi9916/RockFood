﻿using Microsoft.AspNetCore.Http;
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
        public void PutFood(int id, double number = 1)
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
        public string DeleteFood(int id)
        {
            var food = _context.Get(id);
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
