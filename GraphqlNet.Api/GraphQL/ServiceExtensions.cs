using GraphqlNet.Api.GraphQL.Mutations;
using GraphqlNet.Api.GraphQL.Queries;
using GraphqlNet.Api.GraphQL.Subscriptions;
using GraphqlNet.Api.Middlewares;
using HotChocolate.Execution;
using HotChocolate.Execution.Configuration;

namespace GraphqlNet.Api.GraphQL;

public static partial class ServiceExtensions
{
    public static IRequestExecutorBuilder AddGraphQLFacilities(this IServiceCollection services)
    {
        return services
            .AddGraphQLServer()
            .ModifyOptions(opt => opt.DefaultResolverStrategy = ExecutionStrategy.Serial)
            .AddMutationType<Mutation>()
            .AddQueryType<Query>() 
            .UseField<CustomLoggingMiddleware>()   
            .AddProjections()
            .AddFiltering()
            .AddSorting()
            .AddSubscriptionType<Subscription>()
            .AddInMemorySubscriptions()
            .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);
    }
}
