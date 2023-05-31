/** @type {import('next').NextConfig} */
const nextConfig = {
  // TODO: configure to work with our API
  images: {
    remotePatterns: [
      {
        protocol: "https",
        hostname: "src.zakaz.atbmarket.com",
        port: "",
        pathname: "/cache/photos/13243/catalog_list_13243.jpg",
      },
    ],
  },
  experimental: {
    serverActions: true,
  },
};

module.exports = nextConfig;
