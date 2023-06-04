import { getCategory, getProductsInCategory } from "@api";
import ProductCard from "@components/ProductCard";
import ProductCardAddToCart from "@components/ProductCardAddToCart";

type Props = {
  params: {
    categoryId: string;
  };
};

export default async function ProductsInCategory({ params }: Props) {
  const products = await getProductsInCategory(params.categoryId);

  return (
    <div className="flex flex-col gap-6">
      <h1 className="font-bold text-3xl">
        Товари у категорії
        {' "' + (await getCategory(params.categoryId))?.title + '"'}
      </h1>
      <div className="items-center grid grid-cols-4 gap-6">
        {products.map((p) => (
          <ProductCard key={p.id} product={p}>
            <ProductCardAddToCart product={p} />
          </ProductCard>
        ))}
      </div>
    </div>
  );
}
