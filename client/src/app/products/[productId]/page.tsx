import { addToCart, getProduct } from "@api";
import { Product } from "@models";
import Favourite from "@assets/favourite.png";
import Cart from "@assets/cart.png";

import Image from "next/image";

type Props = {
  params: {
    productId: string;
  };
};

export default async function ProductPage({ params }: Props) {
  const product: Product = await getProduct(params.productId);
  const available = product.amount > 0;

  return (
    <div className="bg-white p-6 rounded">
      <div className="flex justify-between">
        {product.discount > 0 ? (
          <span
            className="badge bg-red-500 text-white px-2 py-3"
            style={{ marginLeft: -6 }}
          >
            {`-${(product.discount * 100).toFixed()}%`}
          </span>
        ) : (
          <span />
        )}
        <button className="btn btn-primary pt-2 bg-brand-500 h-full px-2">
          <Image src={Favourite} alt="Favourite" />
        </button>
      </div>
      <div className="flex mr-12 gap-6">
        <Image
          src={product.imageUrl}
          className="w-96 h-full"
          width={500}
          height={500}
          alt={product.title}
        />
        <div className="flex flex-col gap-6 mt-12 mb-6">
          <h1 className="font-bold text-3xl">{product.title}</h1>
          <p className="text-lg h-64">{product.description}</p>
          <span
            className={`badge p-3 text-white bg-${available ? "brand" : "gray"
              }-500`}
          >
            {available ? "Є" : "Немає"} в наявності
          </span>
          <div className="flex justify-around">
            <h3 className="grid grid-cols-2 gap-y-0">
              <span
                className={
                  "font-semibold line-through col-span-full text-lg " +
                  (product.discount ? "text-gray-500" : "text-transparent")
                }
              >
                {product.price}
              </span>
              <span
                className={
                  "justify-start font-bold text-3xl" +
                  (product.discount ? " text-red-500" : "")
                }
              >
                {(product.price * (1 - product.discount)).toFixed(2)}
              </span>
              <span className="justify-center font-normal text-3xl">
                грн/шт
              </span>
            </h3>
            <form action={addToCart}>
              <input
                readOnly
                type="hidden"
                name="productId"
                value={product.id}
              />
              <button
                type="submit"
                className="btn btn-primary pt-2 bg-brand-500 h-14 mt-4 px-4 flex justify-around gap-2"
              >
                <h4 className="h-full py-1 text-lg font-semibold">У кошик</h4>
                <Image src={Cart} alt="Cart" />
              </button>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
}
