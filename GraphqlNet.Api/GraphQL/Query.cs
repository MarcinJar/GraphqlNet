using GraphqlNet.Api.Data;
using GraphqlNet.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphqlNet.Api.GraphQL;

public partial class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Book> GetBooks([Service] AppDbContext dbContext)
    {
        return dbContext.Books;
    }


    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Person> GetPersons([Service] AppDbContext dbContext)
    {
        return dbContext.Persons;
    }
}