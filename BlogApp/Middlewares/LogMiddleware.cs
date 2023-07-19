using BlogApp.Logger.Logger;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace BlogApp.Middlewares
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly BlogApp.Logger.Logger.ILogger _logger;
        public LogMiddleware(RequestDelegate next, BlogApp.Logger.Logger.ILogger logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            _logger.WriteEvent("IP-адрес клиента: " + httpContext.Connection.RemoteIpAddress.ToString());
            await _next(httpContext);
        }
    }
}
