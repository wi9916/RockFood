using Entity.Data.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IFoodServices _foodServices;
        public FoodMVCController(IFoodServices foodServices)
        {
            _foodServices = foodServices;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_foodServices.Get());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var food = _foodServices.Get(id);
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
        public IActionResult Create(Food food)
        {
            if (!ModelState.IsValid)
                return View(food);
                
            _foodServices.Add(food);
            _foodServices.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var food = _foodServices.Get(id);
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

            _foodServices.Edit(food);
            _foodServices.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            _foodServices.BuyFood(id);
            _foodServices.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _foodServices.Delete(id);
            _foodServices.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
