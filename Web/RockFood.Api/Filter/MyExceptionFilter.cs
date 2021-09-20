using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockFood.Api.Filter
{
    public class MyExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<MyExceptionFilter> _logger;
        public MyExceptionFilter(ILogger<MyExceptionFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            _logger.LogError($"{DateTimeOffset.UtcNow} Error: {context.Exception}");
            context.ExceptionHandled = true;
        }
    }
}
