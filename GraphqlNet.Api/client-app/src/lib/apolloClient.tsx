// src/ApolloClient.js
import { ApolloClient, InMemoryCache } from '@apollo/client';

const client = new ApolloClient({
  uri: 'https://localhost:7075/graphql', // Replace with your GraphQL server URL
  cache: new InMemoryCache(),
});

export default client;