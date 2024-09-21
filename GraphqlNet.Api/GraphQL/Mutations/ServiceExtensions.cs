using HotChocolate.Execution.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GraphqlNet.Api.GraphQL.Mutations;

public static partial class ServiceExtensions
{
    public static IRequestExecutorBuilder AddMutations(this IRequestExecutorBuilder services)
    {
        return services.AddMutationType<Mutation>();
    }
}
