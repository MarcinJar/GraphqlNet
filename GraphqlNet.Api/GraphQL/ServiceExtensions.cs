
using GraphqlNet.Api.GraphQL.Queries;
using HotChocolate.Execution.Configuration;

namespace GraphqlNet.Api.GraphQL.Mutations;

public static partial class ServiceExtensions
{
    public static IRequestExecutorBuilder AddQueryAndMutation(this IRequestExecutorBuilder services)
    {
        return services
            .AddMutationType<Mutation>()
            .AddQueryType<Query>();
    }
}
