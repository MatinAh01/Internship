using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Log_With_Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("Handling request: {Method} {Path}", context.Request.Method, context.Request.Path);

            await _next(context); // Call the next middleware

            _logger.LogInformation("Response status: {StatusCode}", context.Response.StatusCode);
        }
    }
}