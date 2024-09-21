using GraphqlNet.Api.Data;
using GraphqlNet.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphqlNet.Api.GraphQL.Queries.AuthorQuery;

public class AuthorType : ObjectType<Author>
{
    protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
    {
        // descriptor.Field(a => a.Books).ResolveWith<Resolvers>(r => Resolvers.GetBooks(default!, default!));
        descriptor.Field(a => a.Books).UseDataloader<BookDataLoader>();
    }

    private class BookDataLoader(
        AppDbContext dbContext, 
        IBatchScheduler batchScheduler) : BatchDataLoader<Guid, List<Book>>(batchScheduler)
    {
        protected override async Task<IReadOnlyDictionary<Guid, List<Book>>> LoadBatchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken)
        {
            var bookReviews = await dbContext.Books
                .Where(r => keys.Contains(r.AuthorID))
                .ToListAsync(cancellationToken);

            return bookReviews.GroupBy(r => r.AuthorID)
                .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}