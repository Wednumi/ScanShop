import "./globals.css";
import { Inter } from "next/font/google";

import Header from "@components/Header";
import Footer from "@components/Footer";

const inter = Inter({ subsets: ["latin"] });

export const metadata = {
  title: "Scan&Shop",
  description: '"Scan and Shop" grocery store',
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
      <body className={inter.className}>
        <div id="overlay-root" />
        {/* @ts-ignore */}
        <Header />
        <main className="p-16">{children}</main>
        <Footer />
      </body>
    </html>
  );
}
