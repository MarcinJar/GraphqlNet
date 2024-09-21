using GraphqlNet.Api.Data;
using GraphqlNet.Api.GraphQL.Queries;
using GraphqlNet.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphqlNet.Api.GraphQL.Queries.AuthorQuery;

public class BookType : ObjectType<Book>
{
    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        descriptor.Field(a => a.BookReviews).UseDataloader<BookReviewDataLoader>();
    }

    private class BookReviewDataLoader(
        AppDbContext dbContext, 
        IBatchScheduler batchScheduler) : BatchDataLoader<Guid, List<BookReview>>(batchScheduler)
    {
        protected override async Task<IReadOnlyDictionary<Guid, List<BookReview>>> LoadBatchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken)
        {
            var bookReviews = await dbContext.BookReviews
                .Where(r => keys.Contains(r.BookID))
                .ToListAsync(cancellationToken);

            return bookReviews.GroupBy(r => r.BookID)
                .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}