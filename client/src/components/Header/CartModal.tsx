"use client";

import { makeOrder } from "@api";
import { ProductInCart } from "@models";

import Image from "next/image";

type Props = {
  setShow: React.Dispatch<React.SetStateAction<boolean>>;
  cart: ProductInCart[];
};

export default function CartModal({ setShow, cart }: Props) {
  const cartPrice = cart.reduce((a, p) => a + p.amount * p.product.price, 0);

  return (
    <div
      onClick={() => setShow(false)}
      className="fixed top-0 left-0 w-screen h-screen flex justify-center items-center bg-gray-600 bg-opacity-50 z-10"
    >
      <div
        className="w-96 h-auto rounded-lg bg-white z-20 flex flex-col gap-4 items-center"
        onClick={(e) => e.stopPropagation()}
      >
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
        <form
          action={makeOrder}
          className="w-1/2 text-white text-xl font-bold mb-3"
        >
          <button type="submit" className="w-full btn btn-warning">
            Замовити
          </button>
        </form>
      </div>
    </div>
  );
}
