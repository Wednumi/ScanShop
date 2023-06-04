"use client";

import { Product } from "@models";
import CartIcon from "@assets/cart.png";

import Image from "next/image";
import Link from "next/link";
import { addToCart } from "@api";
import { ReactNode } from "react";

type Props = {
  product: Product;
  children: ReactNode;
};

export default function ProductCard({ product, children }: Props) {
  return (
    <div className="card card-compact w-full h-full bg-white shadow-xl hover:drop-shadow-xl">
      <Link href={`/products/${product.id}`} className="card">
        <Image
          width={200}
          height={200}
          src={product.imageUrl}
          alt={product.title}
          className="self-center"
        />
        <div className="card-body">
          <h2 className="card-title font-normal h-20">{product.title}</h2>
        </div>
      </Link>
      <div className="card-body">
        <div className="flex justify-between w-full">
          <h3 className="grid grid-cols-2 gap-y-0">
            <span
              className={
                "font-semibold line-through col-span-full " +
                (product.discount ? "text-gray-500" : "text-transparent")
              }
            >
              {product.price}
            </span>
            <span
              className={
                "justify-start font-bold text-lg" +
                (product.discount ? " text-red-500" : "")
              }
            >
              {(product.price * (1 - product.discount)).toFixed(2)}
            </span>
            <span className="justify-center font-normal text-lg">грн/шт</span>
          </h3>
          {children}
        </div>
      </div>
    </div>
  );
}
