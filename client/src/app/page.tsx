import ProductCard from "@/components/ProductCard";

export default async function Home() {
  let product = {
    name: "Тушка курчат-бройлерів Чебатурочка охолоджена",
    price: 86.99,
    countable: true,
    discount: 0.1,
    description: "",
    isAvailable: true,
  };
  return (
    <main className="flex min-h-screen flex-col items-center justify-between p-24">
      <div className="w-1/4 h-1/3">
        <ProductCard product={product} />
      </div>
    </main>
  );
}
