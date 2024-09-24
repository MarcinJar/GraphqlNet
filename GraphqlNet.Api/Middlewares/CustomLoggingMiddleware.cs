using HotChocolate.Resolvers;

namespace GraphqlNet.Api.Middlewares;

public class CustomLoggingMiddleware
{
    private readonly FieldDelegate _next;

    public CustomLoggingMiddleware(FieldDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(IMiddlewareContext context)
    {
        Console.WriteLine($"Executing field {context.Selection.Field}");

        await _next(context);

        Console.WriteLine($"Executed field {context.Selection.Field}");
    }
}