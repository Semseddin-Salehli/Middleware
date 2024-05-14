using Azure.Core;
using Microsoft.Extensions.Logging;
using Middleware.Controllers;
using System.Collections;

namespace Middleware.Middlewares
{
    public class ControlMiddleware
    {

        private readonly ILogger<ControlMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ControlMiddleware(RequestDelegate next, ILogger<ControlMiddleware> logger)
        {
            _logger = logger;
            _logger.LogInformation("NLog enjected into ControlMiddleware");
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("ControlMiddleware invoke 1 called!");

            if (httpContext.Request.RouteValues.TryGetValue("text", out var value) && value.Equals("deneme")) 
            {
                _logger.LogInformation("text : "+ value);
            }

          

            if(httpContext.Request.HasFormContentType && httpContext.Request.Form.TryGetValue("text", out var value2) && value2 == "deneme")
            {
                _logger.LogInformation("text : " + value2);
            }

            await _next(httpContext);
        }
    }
}
