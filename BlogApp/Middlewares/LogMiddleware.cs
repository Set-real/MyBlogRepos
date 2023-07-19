namespace BlogApp
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Ilogger _logger;
        public LogMiddleware(RequestDelegate next, Ilogger logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            _logger.WriteEvent($"Произведен вход в {httpContext.Connection}");
            await _next(httpContext);
        }
    }
}
