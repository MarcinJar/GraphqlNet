using GraphqlNet.Api.Data;
using GraphqlNet.Api.Models;

namespace GraphqlNet.Api.GraphQL.Queries;

public partial class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Person> GetPersons([Service] AppDbContext dbContext)
    {
        return dbContext.Persons;
    }
}