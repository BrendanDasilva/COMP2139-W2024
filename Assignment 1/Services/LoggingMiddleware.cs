namespace Assignment1.Services
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
      // Log the request path
      _logger.LogInformation($"Request: {context.Request.Path}");

      // Call the next middleware in the pipeline
      await _next(context);

      // Log the response status code
      _logger.LogInformation($"Response: {context.Response.StatusCode}");
    }
  }

}
