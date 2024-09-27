using GraphqlNet.Api.Data;
using GraphqlNet.Api.GraphQL;
using GraphqlNet.Api.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddDbContextPool<AppDbContext>(options =>
    options.UseSqlite("Data Source=./Data/PublishingHouseDB.db"));

builder.Services.AddGraphQLFacilities();

builder.Logging.AddConsole(); 

var app = builder.Build();

app.UseCors("AllowAllOrigins"); 

// app.UseLoggingMiddleware();
app.UseErrorHandlingMiddleware();
app.UseTimeoutMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseWebSockets();

app.UseRouting();

app.MapGraphQL();
app.MapControllers(); 

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        System.IO.Path.Combine(Directory.GetCurrentDirectory(), "client-app", ".next")),
    RequestPath = "/_next"
});

app.UseWhenNotBackendMapFallback();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseWhen(context => !context.Request.Path.StartsWithSegments("/graphql"), appBranch =>
    {
        appBranch.UseSpa(spa =>
        {
            spa.Options.SourcePath = "client-app"; // Your Next.js source folder
            spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");
        });
    });
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated(); 
}

app.Run();
