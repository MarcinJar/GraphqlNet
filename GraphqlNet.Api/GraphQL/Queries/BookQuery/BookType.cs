using GraphqlNet.Api.Data;
using GraphqlNet.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphqlNet.Api.GraphQL.Queries.AuthorQuery;

public class BookType : ObjectType<Book>
{
    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        descriptor.Field(a => a.BookReviews).UseDataloader<BookReviewDataLoader>();
        descriptor.Field(a => a.BookEditions).UseDataloader<BookEditionDataLoader>();
    }

    private class BookReviewDataLoader(
        AppDbContext dbContext, 
        IBatchScheduler batchScheduler) : BatchDataLoader<Guid, List<BookReview>>(batchScheduler)
    {
        protected override async Task<IReadOnlyDictionary<Guid, List<BookReview>>> LoadBatchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken)
        {
            var reviews = await dbContext.BookReviews
                .Where(r => keys.Contains(r.BookID))
                .ToListAsync(cancellationToken);

            return reviews.GroupBy(r => r.BookID)
                .ToDictionary(g => g.Key, g => g.ToList());
        }
    }

    private class BookEditionDataLoader(
        AppDbContext dbContext, 
        IBatchScheduler batchScheduler) : BatchDataLoader<Guid, List<BookEdition>>(batchScheduler)
    {
        protected override async Task<IReadOnlyDictionary<Guid, List<BookEdition>>> LoadBatchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken)
        {
            var editions = await dbContext.BookEditions
                .Where(r => keys.Contains(r.BookID))
                .ToListAsync(cancellationToken);

            return editions.GroupBy(r => r.BookID)
                .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}