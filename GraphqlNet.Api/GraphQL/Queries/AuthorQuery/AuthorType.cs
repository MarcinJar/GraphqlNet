using GraphqlNet.Api.Data;
using GraphqlNet.Api.Models;

namespace GraphqlNet.Api.GraphQL.Queries.AuthorQuery;

public class AuthorType : ObjectType<Author>
{
    protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
    {
        descriptor.Field(a => a.Books).ResolveWith<Resolvers>(r => Resolvers.GetBooks(default!, default!));
    }

    private class Resolvers
    {
        public static IQueryable<Book> GetBooks(Author author, [Service] AppDbContext context) =>
            context.Books.Where(b => b.AuthorID == author.ID);
    }
}