"use client";

import Categories from "@assets/categories.png";
import OverlayElement from "@components/OverlayElement";

import Image from "next/image";
import { useEffect, useState } from "react";
import CategoriesBar from "./CategoriesBar";
import { Category } from "@models";

type Props = {
  categories: Category[];
};

export default function CategoriesButton({ categories }: Props) {
  const [showCategories, setShowCategories] = useState(false);
  useEffect(() => {
    document.body.style.overflow = showCategories ? "hidden" : "unset";
  }, [showCategories]);

  return (
    <>
      {showCategories && (
        <OverlayElement
          element={
            <CategoriesBar
              categories={categories}
              setShow={setShowCategories}
            />
          }
        />
      )}
      <button
        className="rounded-xl bg-brand-700 flex p-3 gap-4 items-center hover:bg-brand-800"
        onClick={() => setShowCategories(true)}
      >
        <Image width={35} height={35} src={Categories} alt="Categories" />
        <h1 className="text-white font-bold text-xl">Каталог товарів</h1>
      </button>
    </>
  );
}
