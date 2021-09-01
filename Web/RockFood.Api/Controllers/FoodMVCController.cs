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
            return View(food);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Composition,ProductionDate,UseToDate,ProductsTypeName,Id,Name,ImageName,CompanyId,SellerId,About,Price,Count")] Food food)
        {
            if (ModelState.IsValid)
            {
                _context.Add(food);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(food);
        }

        // GET: FoodMVCController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FoodMVCController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FoodMVCController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FoodMVCController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
