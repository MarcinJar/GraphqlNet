import "@/styles/globals.css";
import ApolloProvider from "@/lib/apolloProvider";

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body className={`antialiased`}>
        <ApolloProvider>
          {children}
        </ApolloProvider>
      </body>
    </html>
  );
}
