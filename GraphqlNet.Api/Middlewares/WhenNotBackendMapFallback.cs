namespace GraphqlNet.Api.Middlewares;

public static class WhenNotBackendMapFallbackExitension
{
    public static IApplicationBuilder UseWhenNotBackendMapFallback(this IApplicationBuilder @this)
    {
        return @this.UseWhen(context => !context.Request.Path.StartsWithSegments("/graphql"), appBranch =>
        {
            appBranch.UseEndpoints(endpoints => endpoints.MapFallback(async context =>
            {
                var path = context.Request.Path.Value;

                var pathSplited = path?.Split("/") ?? [];

                var allPathParams = new List<string> { Directory.GetCurrentDirectory(), "client-app", ".next", "server", "app" };

                allPathParams.AddRange(pathSplited);
                allPathParams.ForEach(path => Console.WriteLine(path));
                allPathParams.Remove(string.Empty);

                if (allPathParams.Contains(string.Empty))
                {
                    allPathParams.Add("index");
                }

                var filePath = System.IO.Path.Combine([.. allPathParams]) + ".html";

                context.Response.ContentType = "text/html";
                await context.Response.SendFileAsync(filePath);
            }));
        });
    }
}