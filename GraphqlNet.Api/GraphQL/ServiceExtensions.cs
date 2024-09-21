using GraphqlNet.Api.GraphQL.Queries;
using HotChocolate.Execution.Configuration;

namespace GraphqlNet.Api.GraphQL.Mutations;

public static partial class ServiceExtensions
{
    public static IRequestExecutorBuilder AddGraphQLFacilities(this IServiceCollection services)
    {
        return services
            .AddGraphQLServer()
            .AddMutationType<Mutation>()
            .AddQueryType<Query>()    
            .AddProjections()
            .AddFiltering()
            .AddSorting()
            .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);
    }
}
