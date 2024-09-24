using GraphqlNet.Api.Data;
using GraphqlNet.Api.Models;

namespace GraphqlNet.Api.GraphQL.Queries;

public partial class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("Get a list of books")]
    public IQueryable<Book> GetBooks([Service] AppDbContext dbContext)
    {
        return dbContext.Books;
    }

    [GraphQLDescription("Get the total count of books")]
    [GraphQLName("totalBooks")]
    public int TotalBooksCount([Service] AppDbContext dbContext)
    {
        return dbContext.Books.Count();
    }
}