using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RockFood.Api.Filter
{
    public class BuyFoodActionFilter : IActionFilter
    {
        private readonly ILogger<BuyFoodActionFilter> _logger;
        public BuyFoodActionFilter(ILogger<BuyFoodActionFilter> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"{DateTimeOffset.UtcNow} ActionFilter(OnActionExecuted) " +
                $"Path: {context.HttpContext.Request.Path.Value}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"{DateTimeOffset.UtcNow} ActionFilter(OnActionExecuting) ");
        }       
    }
}
