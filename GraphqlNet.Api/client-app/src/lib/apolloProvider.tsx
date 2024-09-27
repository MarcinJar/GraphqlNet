'use client'; 

import { ApolloProvider as Provider } from '@apollo/client';
import { ReactNode } from 'react';
import client from './apolloClient';

interface ApolloProviderProps {
  children: ReactNode;
}

const ApolloProvider = ({ children }: ApolloProviderProps) => {
  return (
    <Provider client={client}>
      {children}
    </Provider>
  );
};

export default ApolloProvider;
