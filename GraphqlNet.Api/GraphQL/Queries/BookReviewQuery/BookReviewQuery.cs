using GraphqlNet.Api.Data;
using GraphqlNet.Api.Models;

namespace GraphqlNet.Api.GraphQL.Queries;

public partial class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<BookReview> GetAllRewiews([Service] AppDbContext dbContext)
    {
        return dbContext.BookReviews;
    }

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<BookReview> GetBookRewiews(Guid bookId, [Service] AppDbContext dbContext)
    {
        return dbContext.BookReviews.Where(r => r.BookID == bookId);
    }

    
    public int TotalRewiewsCount([Service] AppDbContext dbContext)
    {
        return dbContext.BookReviews.Count();
    }
}