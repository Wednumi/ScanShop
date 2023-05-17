"use client";

import { Product } from "@/models";

import Image from "next/image";

type Props = {
  product: Product;
};

export default function ProductCard({ product }: Props) {
  return (
    <div className="card card-compact w-full bg-white shadow-xl">
      <Image
        width={200}
        height={200}
        src="https://src.zakaz.atbmarket.com/cache/photos/13243/catalog_list_13243.jpg"
        alt={product.name}
      />
      <div className="card-body grid grid-cols-2">
        <h2 className="card-title col-span-2 font-normal">{product.name}</h2>
        <h3 className="card-title">
          <span className="font-bold">{product.price}</span>
          <span className="font-normal">
            грн/ {product.countable ? "шт" : "кг"}
          </span>
        </h3>
        <div className="card-actions justify-end">
          <button className="btn btn-primary">TODO</button>
        </div>
      </div>
    </div>
  );
}
