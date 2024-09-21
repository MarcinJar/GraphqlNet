using GraphqlNet.Api.Data;
using GraphqlNet.Api.Models;

namespace GraphqlNet.Api.GraphQL.Mutations;

public partial class Mutation
{
    public async Task<Author> AddAuthorAsync(Guid personId, string name, [Service] AppDbContext context)
    {
        var person = context.Persons
            .FirstOrDefault(a => a.ID == personId) ?? throw new InvalidOperationException("Author not found.");

        var newAuthor = new Author
        {
            ID = Guid.NewGuid(),
            Person = person,
            Books = []
        };

        context.Authors.Add(newAuthor);
        await context.SaveChangesAsync();

        return newAuthor;
    }
}
