import Close from "@assets/close.png";
import SaleProducts from "@assets/sale-products.png";
import NewProducts from "@assets/new-products.png";
import BakeryProducts from "@assets/bakery-products.png";
import SeafoodProducts from "@assets/seafood-products.png";
import MeatProducts from "@assets/meat-products.png";
import VegetableProducts from "@assets/vegetable-products.png";
import MilkProducts from "@assets/milk-products.png";
import BeverageProducts from "@assets/beverage-products.png";

import Image from "next/image";
import Link from "next/link";
import OverlayEscape from "./OverlayEscape";
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
    <OverlayEscape
      setShow={setShow}
      styles={
        "fixed top-0 left-0 w-screen h-screen flex flex-col items-start bg-gray-600 bg-opacity-50 z-10"
      }
    >
      <CategoryCancelButton setShow={setShow} />
      <StopPropagationWrapper>
        <div className="grid grid-cols-5 w-screen justify-around text-xl font-semibold uppercase text-center mt-5">
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
    </OverlayEscape>
  );
}
