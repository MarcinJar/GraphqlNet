using GraphqlNet.Api.Data;
using GraphqlNet.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphqlNet.Api.GraphQL.Mutations;

public partial class Mutation
{
    public async Task<Author> AddAuthorAsync(Guid personId, [Service] AppDbContext dbContext)
    {
        var person = await dbContext.Persons
            .FirstOrDefaultAsync(a => a.ID == personId) ?? throw new InvalidOperationException("Author not found.");

        var newAuthor = new Author
        {
            ID = Guid.NewGuid(), 
            Person = person,
            Books = []
        };

        dbContext.Authors.Add(newAuthor);
        await dbContext.SaveChangesAsync();

        return newAuthor;
    }
}
