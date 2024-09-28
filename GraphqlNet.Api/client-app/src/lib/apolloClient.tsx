// src/ApolloClient.js
import { ApolloClient, InMemoryCache } from '@apollo/client';

const client = new ApolloClient({
  uri: process.env.NEXT_PUBLIC_GRAPHQL_BACKEND_URL, // Replace with your GraphQL server URL
  cache: new InMemoryCache(),
});

export default client;

let apolloClient: ApolloClient<any>;

function createApolloClient() {
  return new ApolloClient({
    uri: 'YOUR_GRAPHQL_API_ENDPOINT', // Replace with your GraphQL endpoint
    cache: new InMemoryCache(),
  });
}

export function initializeApollo(initialState = {}) {
  // Create a new Apollo Client instance if it doesn't exist
  const client = apolloClient ?? createApolloClient();

  // If the client is already created, reset the cache to the initial state
  if (initialState) {
    client.cache.restore(initialState);
  }

  // If running in a server environment, set the client instance
  if (typeof window === 'undefined') {
    return client;
  }

  // Create the Apollo Client instance once for the browser
  if (!apolloClient) {
    apolloClient = client;
  }

  return client;
}