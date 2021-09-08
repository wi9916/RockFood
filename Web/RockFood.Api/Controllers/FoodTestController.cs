using Entity.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockFood.Api.Controllers
{    
    [ApiController]
    [Route("api/[controller]")]
    public class FoodTestController : ControllerBase
    {
        public static UnitOfWork _unitOfWork;
        public FoodTestController()
        {
            _unitOfWork = new UnitOfWork();
        }
        [HttpGet]
        [Route("Foods")]
        public IEnumerable<Food> GetFoods()
        {
            var foods = _unitOfWork.Foods.GetAll();
            return foods;
        }

    }
}
