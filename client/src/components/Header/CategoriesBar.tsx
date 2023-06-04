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

type Props = {
  setShow: React.Dispatch<React.SetStateAction<boolean>>;
};

export default function Sidebar({ setShow }: Props) {
  return (
    <OverlayEscape
      setShow={setShow}
      styles={
        "fixed top-0 left-0 w-screen h-screen flex flex-col items-start bg-gray-600 bg-opacity-50 z-10"
      }
    >
      <CategoryCancelButton setShow={setShow} />
      <StopPropagationWrapper>
        <Link
          href="/"
          className="w-auto flex gap-3 items-center p-3 justify-self-center"
        >
          <Image width={35} height={35} src={SaleProducts} alt="On sale" />
          <p className="font-bold text-lg">Знижки</p>
        </Link>
        <Link href="/" className="w-auto flex gap-3 items-center p-3">
          <Image width={35} height={35} src={BakeryProducts} alt="Bakery" />
          <p className="text-lg">Хлібобулочні вироби</p>
        </Link>
        <Link href="/" className="w-auto flex gap-3 items-center p-3">
          <Image width={35} height={35} src={MeatProducts} alt="Meat" />
          <p className="text-lg">{"М'ясо та яйця"}</p>
        </Link>
        <Link href="/" className="w-auto flex gap-3 items-center p-3">
          <Image width={35} height={35} src={MilkProducts} alt="Milk" />
          <p className="text-lg">Молочні продукти</p>
        </Link>
        <Link
          href="/"
          className="w-auto flex gap-3 items-center p-3 justify-self-center"
        >
          <Image width={35} height={35} src={NewProducts} alt="New" />
          <p className="font-bold text-lg">Новинки</p>
        </Link>
        <Link href="/" className="w-auto flex gap-3 items-center p-3">
          <Image width={35} height={35} src={SeafoodProducts} alt="Seafood" />
          <p className="text-lg">Риба та морепродукти</p>
        </Link>
        <Link href="/" className="w-auto flex gap-3 items-center p-3">
          <Image
            width={35}
            height={35}
            src={VegetableProducts}
            alt="Vegetable"
          />
          <p className="text-lg">Овочі та фрукти</p>
        </Link>
        <Link href="/" className="w-auto flex gap-3 items-center p-3">
          <Image width={35} height={35} src={BeverageProducts} alt="Beverage" />
          <p className="text-lg">Напої</p>
        </Link>
      </StopPropagationWrapper>
    </OverlayEscape>
  );
}
