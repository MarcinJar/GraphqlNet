namespace GraphqlNet.Api.Middlewares;

public static class WhenNotBackendMapFallbackExitension
{
    public static IEndpointConventionBuilder UseWhenNotBackendMapFallback(this WebApplication @this)
    {
        return @this.MapFallback(async context =>
        {
            var path = context.Request.Path.Value;

            if (path?.StartsWith("/graphql") ?? false)
                return;

            var pathSplited = (path?.Split("/", StringSplitOptions.RemoveEmptyEntries) ?? []).ToList();

            if (pathSplited is [])
                pathSplited.Add("index");

            var allPathParams = new List<string> { Directory.GetCurrentDirectory(), "client-app", ".next", "server", "app" };

            allPathParams.AddRange(pathSplited);

            var filePath = System.IO.Path.Combine([.. allPathParams]) + ".html";

            context.Response.ContentType = "text/html";
            await context.Response.SendFileAsync(filePath);
        });
    }
}