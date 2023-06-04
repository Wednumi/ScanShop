import { ProductInCart } from "@models";

import Image from "next/image";
import { ReactNode } from "react";

type Props = {
  cart: ProductInCart[];
  children: ReactNode;
};

export default function CartModal({ cart, children }: Props) {
  const cartPrice = cart.reduce((a, p) => a + p.amount * p.product.price, 0);

  return (
    <>
      <div className="w-full py-4 rounded-t-lg bg-brand-500 text-center align-middle">
        <p className="text-2xl text-white">Кошик</p>
      </div>
      <div className="w-full max-h-80 overflow-auto flex flex-col justify-center">
        {cart.map((p) => (
          <div
            key={p.product.id}
            className="w-full h-20 flex gap-4 justify-between px-4"
          >
            <div className="text-center">
              <Image
                src={p.product.imageUrl}
                alt={p.product.title}
                width={50}
                height={50}
              />
            </div>
            <span className="text-center">{p.product.title}</span>
            <span className="text-center">{p.amount}</span>
            <form className="ml-3 text-center uppercase text-bold text-red-500 text-5xl">
              <input type="hidden" name="productId" value={p.product.id} />
              <button>-</button>
            </form>
          </div>
        ))}
      </div>
      <p className="text-md">Загальна вартість: {cartPrice.toFixed(2)} грн</p>
      {children}
    </>
  );
}
