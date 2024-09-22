namespace GraphqlNet.Api.Middlewares;

public class LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        logger.LogInformation("Handling request: {Method} {Path}", context.Request.Method, context.Request.Path);

        await next(context);

        logger.LogInformation("Finished handling request with status code: {StatusCode}", context.Response.StatusCode);
    }
}

public static class LoggingMiddlewareExitension
{
    public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder @this)
    {
        return @this.UseMiddleware<LoggingMiddleware>();
    }
}