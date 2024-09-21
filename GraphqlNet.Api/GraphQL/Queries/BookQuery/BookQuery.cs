using GraphqlNet.Api.Data;
using GraphqlNet.Api.Models;

namespace GraphqlNet.Api.GraphQL.Queries;

public partial class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Book> GetBooks([Service] AppDbContext dbContext)
    {
        return dbContext.Books;
    }

    public int TotalBooksCount([Service] AppDbContext dbContext)
    {
        return dbContext.Books.Count();
    }
}