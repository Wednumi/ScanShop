"use client";

import Cart from "@assets/cart.png";
import OverlayElement from "@components/OverlayElement";
import CartModal from "./CartModal";

import Image from "next/image";
import { ReactNode, useEffect, useState } from "react";
import { ProductInCart } from "@models";
import CartModalWrapper from "./CartModalWrapper";

type Props = {
  cart: ProductInCart[];
  children: ReactNode;
};

export default function CartButton({ cart, children }: Props) {
  const [showCart, setShowCart] = useState(false);

  useEffect(() => {
    document.body.style.overflow = showCart ? "hidden" : "unset";
  }, [showCart]);

  const cartSize = cart.reduce((a, p) => a + p.amount, 0);

  return (
    <>
      {showCart && (
        <OverlayElement
          element={
            <CartModalWrapper setShow={setShowCart}>
              <CartModal setShow={setShowCart} cart={cart}>
                {children}
              </CartModal>
            </CartModalWrapper>
          }
        />
      )}
      <button
        className={"rounded p-2 pb-0 hover:bg-brand-600 w-16 flex"}
        onClick={() => setShowCart(true)}
      >
        <Image width={60} src={Cart} alt="Cart" className="h-full" />
        <span
          className="badge bg-red-500 border-none text-white"
          style={{ marginLeft: -15 }}
        >
          {cartSize}
        </span>
      </button>
    </>
  );
}
