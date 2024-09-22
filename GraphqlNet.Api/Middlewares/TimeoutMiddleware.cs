namespace GraphqlNet.Api.Middlewares;

public class TimeoutMiddleware(RequestDelegate  next)
{
    public async Task InvokeAsync(HttpContext context)

    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, context.RequestAborted);

        context.RequestAborted = linkedCts.Token; 

        try
        {
            await next(context); 
        }
        catch (OperationCanceledException)
        {
            context.Response.StatusCode = StatusCodes.Status408RequestTimeout;
            await context.Response.WriteAsync("Request timed out or was aborted.");
        }
    }
}

public static class TimeoutMiddlewareExitension
{
    public static IApplicationBuilder UseTimeoutMiddleware(this IApplicationBuilder @this)
    {
        return @this.UseMiddleware<TimeoutMiddleware>();
    }
}