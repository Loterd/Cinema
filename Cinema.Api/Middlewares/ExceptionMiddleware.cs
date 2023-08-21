using System.Net;

namespace Cinema.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ApiException e)
        {
            context.Response.StatusCode = (int)e.StatusCode;
            context.Response.ContentType = "application/json";
            var exceptionMessage = e.Message;
            
            _logger.LogError(e, e.Message);

            await context.Response.WriteAsync(exceptionMessage);
        }
        catch (Exception e)
        {
            var statusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            var exceptionMessage = e.Message;
            
            _logger.LogError(e, e.Message);

            await context.Response.WriteAsync(exceptionMessage);
        }
    }
}