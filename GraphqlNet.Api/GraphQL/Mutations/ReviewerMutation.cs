using GraphqlNet.Api.Data;
using GraphqlNet.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphqlNet.Api.GraphQL.Mutations;

public partial class Mutation
{
    public async Task<Reviewer> AddReviewerAsync(Guid personId, [Service] AppDbContext dbContext)
    {
        var person = await dbContext.Persons
            .FirstOrDefaultAsync(a => a.ID == personId) ?? throw new InvalidOperationException("Author not found.");

        var newReviewer = new Reviewer
        {
            ID = Guid.NewGuid(), 
            Person = person,
            BookReviews = []
        };

        dbContext.Reviewers.Add(newReviewer);
        await dbContext.SaveChangesAsync();

        return newReviewer;
    }
}
