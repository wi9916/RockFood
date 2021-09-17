using Entity.Data.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IFoodService _foodService;

        public FoodMVCController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_foodService.Get());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var food = _foodService.Get(id);
            if (food != null)
                return View(food);

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
                
            _foodService.Add(food);
            _foodService.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var food = _foodService.Get(id);
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

            _foodService.Edit(food);
            _foodService.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            _foodService.BuyFood(id);
            _foodService.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _foodService.Delete(id);
            _foodService.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
