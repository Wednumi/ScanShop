import ProductCard from "@components/ProductCard";

export default async function Home() {
  const product = {
    id: "1",
    title: "Тушка курчат-бройлерів Чебатурочка охолоджена",
    price: 86.99,
    discount: 0.1,
    description: "",
    amount: 69420,
    imageUrl:
      "https://src.zakaz.atbmarket.com/cache/photos/13243/catalog_list_13243.jpg",
  };
  const product2 = {
    ...product,
    id: "2",
    discount: 0,
  };
  return (
    <main className="min-h-screen items-center p-24 grid grid-cols-4 gap-6">
      <ProductCard product={product} />
      <ProductCard product={product2} />
    </main>
  );
}
