using GraphqlNet.Api.Data;
using GraphqlNet.Api.Models;

namespace GraphqlNet.Api.GraphQL.Queries.BookQuery;

public partial class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<BookReview> GetBookRewiews([Service] AppDbContext dbContext)
    {
        return dbContext.BookReviews;
    }
}