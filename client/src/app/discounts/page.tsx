import { getDiscountedProducts, getUserInfo } from "@api";
import ProductCard from "@components/ProductCard";
import ProductCardAddToCart from "@components/ProductCardAddToCart";

export default async function ProductsInCategory() {
  const products = await getDiscountedProducts();
  const isAdmin = (await getUserInfo())?.role === "admin";

  return (
    <div className="flex flex-col gap-6">
      <h1 className="font-bold text-3xl">Акційні товари</h1>
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
