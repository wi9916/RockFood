using Entity.Data.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using RockFood.Api.Filter;
using RockFood.Interfaces;
using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockFood.Api.Controllers
{
    public class FoodMVCController : Controller
    {
        private readonly IFoodService _context;
        private readonly IWebHostEnvironment _env;

        public FoodMVCController(IFoodService context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_context.Get());
        }

        [HttpGet]
        [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Any, NoStore = false)]       
        public ActionResult Details(int id)
        {
            var food = _context.Get(id);
            if (food != null)
            {
                if(_env.IsDevelopment())
                {
                    food.About += "IsDevelopment";
                }
                if (_env.IsEnvironment("QA"))
                {
                    food.About += "IsQa";
                }
                if (_env.IsEnvironment("Production"))
                {
                    food.About += "IsProduction";
                }
                return View(food);
            }

            return NotFound();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(FoodActionFilter))]
        public IActionResult Create(Food food)
        {
            if (!ModelState.IsValid)
                return View(food);
                
            _context.Add(food);
            _context.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var food = _context.Get(id);
            if (food != null)
                return View(food);

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]        
        public ActionResult Edit(Food food)
        {
            if(!ModelState.IsValid)
                return View(food);

            _context.Edit(food);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            _context.BuyFood(id);
            _context.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _context.Delete(id);
            _context.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
