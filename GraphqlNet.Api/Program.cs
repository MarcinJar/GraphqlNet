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

// Access the IWebHostEnvironment
var env = app.Environment;

// Serve static files from the .next directory
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        System.IO.Path.Combine(Directory.GetCurrentDirectory(), "client-app", ".next")),
    RequestPath = "/_next" // Adjust this path as necessary for your application
});

// Fallback to Next.js for unmatched routes
app.MapFallbackToFile("/index.html", new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        System.IO.Path.Combine(Directory.GetCurrentDirectory(), "client-app", ".next", "server", "app")),
    RequestPath = "" // No request path for the fallback
});

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated(); 
}

app.Run();
