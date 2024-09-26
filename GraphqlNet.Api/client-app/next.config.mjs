/** @type {import('next').NextConfig} */
const nextConfig = {
  async rewrites() {
    return [
      {
        source: '/:path*',
        destination: 'http://localhost:5079/:path*', // Proxy to backend (graphql | /api/ rest)
      },
    ];
  },
};

export default nextConfig;
