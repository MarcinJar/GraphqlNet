// src/ApolloClient.js
import { ApolloClient, InMemoryCache } from '@apollo/client';

const client = new ApolloClient({
  uri: process.env.NEXT_PUBLIC_GRAPHQL_BACKEND_URL, // Replace with your GraphQL server URL
  cache: new InMemoryCache(),
});

export default client;