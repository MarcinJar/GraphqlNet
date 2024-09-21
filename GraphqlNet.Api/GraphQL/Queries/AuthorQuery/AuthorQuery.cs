using GraphqlNet.Api.Data;
using GraphqlNet.Api.Models;

namespace GraphqlNet.Api.GraphQL.Queries.AuthorQuery;

public partial class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Author> GetAuthors([Service] AppDbContext dbContext)
    {
        return dbContext.Authors;
    }
}