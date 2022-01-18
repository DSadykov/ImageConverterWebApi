namespace ImageConverterWebApi.Services
{
    public class LoggingMiddleware : IMiddleware
    {
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(ILogger<LoggingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation("Came {requestType} request from {ip} at {time}", context.Request.Method, context.Connection.RemoteIpAddress, DateTime.Now);
            await next(context);
        }
    }
}
