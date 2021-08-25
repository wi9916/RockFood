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
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {
        public static ShopService _shopService;        

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _shopService = new ShopService();
        }

        [HttpGet]
        [Route("Foods")]
        public IEnumerable<Food> GetFoods()
        {
            var foods = _shopService.Foods.GetAll();
            return foods;
        }

    }
}
