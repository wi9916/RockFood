using Entity.Data.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RockFood.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockFood.Api.Controllers
{
    public class FoodMVCController : Controller
    {
        //private readonly IFoodOperation _context;        
        //public FoodMVCController(IFoodOperation context)
        //{
        //    _context = context;
        //}
        private readonly IShopService _context;
        public FoodMVCController(IShopService context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View(_context.Foods.GetAll());
        }

        // GET: FoodMVCController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FoodMVCController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodMVCController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
