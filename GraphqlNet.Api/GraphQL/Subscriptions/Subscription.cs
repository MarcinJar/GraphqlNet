using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphqlNet.Api.Models;

namespace GraphqlNet.Api.GraphQL.Subscriptions;

public class Subscription
{
    [Subscribe]
    [Topic]
    public Book OnBookAdded([EventMessage] Book book)
    {
        return book;
    }
}

public static class SubscriptionEvents
{
    public const string OnBookAdded = nameof(Subscription.OnBookAdded);
}