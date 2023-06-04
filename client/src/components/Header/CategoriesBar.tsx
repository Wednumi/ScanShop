"use client";

import Link from "next/link";
import CategoryCancelButton from "./CategoryCancelButton";
import StopPropagationWrapper from "./StopPropagationWrapper";
import { Category } from "@models";

type Props = {
  setShow: React.Dispatch<React.SetStateAction<boolean>>;
  categories: Category[];
};

export default function CategoriesBar({ setShow, categories }: Props) {
  categories = categories.slice(0, 8);

  return (
    <div
      onClick={() => setShow(false)}
      className="fixed top-0 left-0 w-screen h-screen flex flex-col items-start bg-gray-600 bg-opacity-50 z-10"
    >
      <CategoryCancelButton setShow={setShow} />
      <StopPropagationWrapper>
        <div className="grid grid-cols-5 w-screen justify-around text-xl font-semibold uppercase text-center mt-5">
          <Link href={"/discounts"} className="h-20">
            <h3>Акційні товари</h3>
          </Link>
          {categories.map((c) => (
            <Link
              key={c.id}
              href={`/products/byCategory/${c.id}`}
              className="h-20"
            >
              <h3>{c.title}</h3>
            </Link>
          ))}
        </div>
      </StopPropagationWrapper>
    </div>
  );
}
