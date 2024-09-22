using System.Net;

namespace GraphqlNet.Api.Middlewares;

public class ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
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

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        logger.LogError(ex, "An unhandled exception occurred");

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var errorResponse = new
        {
            Message = "An unexpected error occurred.",
            Detail = ex.Message 
        };

        return context.Response.WriteAsJsonAsync(errorResponse);
    }
}

public static class ErrorHandlingMiddlewareExitension
{
    public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder @this)
    {
        return @this.UseMiddleware<ErrorHandlingMiddleware>();
    }
}
