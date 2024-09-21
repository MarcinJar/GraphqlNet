
using GraphqlNet.Api.Data;
using GraphqlNet.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphqlNet.Api.GraphQL.Queries.RewiewQuery;

public class ReviewDataLoader : BatchDataLoader<Guid, List<BookReview>>
{
    private readonly AppDbContext _dbContext;

    public ReviewDataLoader(AppDbContext dbContext, IBatchScheduler batchScheduler)
        : base(batchScheduler)
    {
        _dbContext = dbContext;
    }

    protected override async Task<IReadOnlyDictionary<Guid, List<BookReview>>> LoadBatchAsync(
        IReadOnlyList<Guid> keys,
        CancellationToken cancellationToken)
    {
        var bookReviews = await _dbContext.BookReviews
            .Where(r => keys.Contains(r.BookID))
            .ToListAsync(cancellationToken);

        return bookReviews.GroupBy(r => r.BookID)
            .ToDictionary(g => g.Key, g => g.ToList());
    }
}
