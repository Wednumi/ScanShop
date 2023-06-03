"use client";

import Cart from "@assets/cart.png";
import OverlayElement from "@components/OverlayElement";
import CartModal from "./CartModal";

import Image from "next/image";
import { useEffect, useState } from "react";

export default function CartButton({ cartSize }: { cartSize: number }) {
  const [showCart, setShowCart] = useState(false);
  useEffect(() => {
    document.body.style.overflow = showCart ? "hidden" : "unset";
  }, [showCart]);

  return (
    <>
      {showCart && (
        <OverlayElement element={<CartModal setShow={setShowCart} />} />
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
