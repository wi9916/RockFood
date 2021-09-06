﻿using Entity.Data.Interface;
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
        private readonly IFoodOperation _context;
        public FoodMVCController(IFoodOperation context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View(_context.Get());
        }
        public ActionResult Details(int id)
        {
            var food = _context.Get(id);
            if (food != null)
                return View(food);

            return NotFound();
        }
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
                
            _context.Add(food);
            _context.Save();
            return RedirectToAction(nameof(Index));
        }

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
            _context.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Buy(int id)
        {
            _context.BuyFood(id);
            _context.Save();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            _context.Delete(id);
            _context.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}