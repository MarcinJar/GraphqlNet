
using GraphqlNet.Api.Data;
using GraphqlNet.Api.GraphQL.Mutations;
using GraphqlNet.Api.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContextPool<AppDbContext>(options =>
    options.UseSqlite("Data Source=./Data/PublishingHouseDB.db"));

builder.Services.AddGraphQLFacilities();

var app = builder.Build();

app.UseLoggingMiddleware();
app.UseErrorHandlingMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseWebSockets();
app.UseTimeoutMiddleware();
app.MapGraphQL();
app.MapControllers(); 

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated(); 
}

app.Run();
