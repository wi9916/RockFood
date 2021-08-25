﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entity.Data;
using RockFood.Models;
using Entity.Data.Interface;

namespace RockFood.Api.Controllers
{
    [Route("api/FoodController")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IShopService _context;

        public FoodController(IShopService context)
        {
            _context = context;
        }

        [HttpGet("GetFoods")]
        public IEnumerable<Food> GetFood()
        {
            return _context.Foods.GetAll();
        }

        [HttpGet("GetFood")]
        public ActionResult<Food> GetFood(int id)
        {
            var food =  _context.Foods.Get(id);            
            return food;
        }

        [HttpPut("BuyFood")]
        public ActionResult<Food> PutFood(int id)
        {
            var food = _context.Foods.Get(id);
            food.Count--;
            _context.Foods.Update(food);
            _context.Save();           
            return NoContent();
        }

        [HttpPost("AddFood")]
        public ActionResult<Food> AddFood(Food food)
        {
            _context.Foods.Create(food);
            _context.Save();

            return CreatedAtAction("GetFood", new { id = food.Id }, food);
        }

        [HttpDelete("DeleteFood")]
        public ActionResult<string> DeleteFood(int id)
        {
            var food = _context.Foods.Get(id);
            if (food == null)
            {
                return "Not Found";
            }

            _context.Foods.Delete(id);
            _context.Save();
            return "Delate";
        }
    }
}
