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
    public class FoodActionFilter : IAsyncActionFilter
    {
        private readonly ILogger<FoodActionFilter> _logger;
        public FoodActionFilter(ILogger<FoodActionFilter> logger)
        {
            _logger = logger;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {           
            ActionExecutedContext rContext = null;
            string stringContent = string.Empty;

            context.HttpContext.Request.EnableBuffering();
            context.HttpContext.Request.Body.Position = 0;

            using (var reader = new StreamReader(context.HttpContext.Request.Body))
            {
                stringContent = await reader.ReadToEndAsync();
                context.HttpContext.Request.Body.Position = 0;
            }

            rContext = await next();
            _logger.LogInformation($"{DateTimeOffset.UtcNow} ActionFilter " +
                        $"Request of the Body: {stringContent}");
        }
    }
}
