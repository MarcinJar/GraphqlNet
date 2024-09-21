
using GraphqlNet.Api.Data;
using GraphqlNet.Api.GraphQL;
using GraphqlNet.Api.GraphQL.Mutations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
// Register AppDbContext with pooling
builder.Services.AddDbContextPool<AppDbContext>(options =>
    options.UseSqlite("Data Source=./Data/PublishingHouseDB.db"));

// Add GraphQL services
builder.Services
    .AddGraphQLServer()
    .AddQueryAndMutation()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGraphQL();

// Ensure the database is created
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated(); // Ensure SQLite DB is created if it doesn't exist
}

app.Run();
