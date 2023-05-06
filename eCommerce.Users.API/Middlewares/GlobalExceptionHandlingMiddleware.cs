using Newtonsoft.Json;

namespace eCommerce.Users.API.Middlewares;

public sealed class GlobalExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        _logger.LogError(
            "Exception occured: {@Exception} {@InnerException} at {@DateTimeUtc}",
            exception,
            exception?.InnerException,
            DateTime.UtcNow
        );

        var json = JsonConvert.SerializeObject(exception);

        await context.Response.WriteAsync(json);
    }
}
