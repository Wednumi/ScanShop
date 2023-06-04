import { ProductInCart } from "@models";

import Image from "next/image";
import { ReactNode } from "react";

type Props = {
  setShow: React.Dispatch<React.SetStateAction<boolean>>;
  cart: ProductInCart[];
  children: ReactNode;
};

export default function CartModal({ setShow, cart, children }: Props) {
  const cartPrice = cart.reduce((a, p) => a + p.amount * p.product.price, 0);

  return (
    <>
      <div className="w-full py-4 rounded-t-lg bg-brand-500 text-center align-middle">
        <p className="text-2xl text-white">Кошик</p>
      </div>
      <div className="w-full max-h-80 overflow-auto flex flex-col justify-center">
        {cart.map((p) => (
          <div key={p.product.id} className="w-full h-20 flex">
            <div className="basis-1/4 text-center">
              <Image
                src={p.product.imageUrl}
                alt={p.product.title}
                width={50}
                height={50}
              />
            </div>
            <div className="basis-1/2 text-center">{p.product.title}</div>
            <div className="basis-1/4 text-center">{p.amount}</div>
          </div>
        ))}
      </div>
      <p className="text-md">Загальна вартість: {cartPrice.toFixed(2)} грн</p>
      {children}
    </>
  );
}
