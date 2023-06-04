import { getProducts, getUserInfo } from "@api";
import ProductCard from "@components/ProductCard";
import ProductCardAddToCart from "@components/ProductCardAddToCart";
import AddProduct from "@assets/add-product.png";

import Image from "next/image";
import Link from "next/link";

export default async function Home() {
  const products = await getProducts();
  const isAdmin = (await getUserInfo())?.isAdmin || false;

  return (
    <div className="flex flex-col gap-6">
      <div className="flex justify-between">
        <h1 className="font-bold text-3xl">Рекомандації</h1>
        {isAdmin && (
          <Link
            href="/products/add"
            className="flex bg-brand-500 rounded-lg font-bold text-xl p-3 text-white text-center gap-6 hover:bg-brand-600"
          >
            <Image src={AddProduct} alt="Add product" />
            <span className="mt-1 pr-2">Додати товар</span>
          </Link>
        )}
      </div>
      <div className="items-center grid grid-cols-4 gap-6">
        {products.map((p) => (
          <ProductCard key={p.id} product={p} isAdmin={isAdmin}>
            <ProductCardAddToCart product={p} />
          </ProductCard>
        ))}
      </div>
    </div>
  );
}
