using GraphqlNet.Api.GraphQL.Queries.RewiewQuery;
using GraphqlNet.Api.Models;

namespace GraphqlNet.Api.GraphQL.Queries.AuthorQuery;

public class BookType : ObjectType<Book>
{
    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        descriptor.Field(a => a.BookReviews).UseDataloader<ReviewDataLoader>();
    }
}