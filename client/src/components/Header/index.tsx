import { getCart } from "@api";
import Logo from "@assets/Logo.png";
import CategoriesButton from "./CategoriesButton";
import SearchField from "./SearchField";
import FavouriteButton from "./FavouriteButton";
import CartButton from "./CartButton";
import MenuButton from "./MenuButton";

import Image from "next/image";
import Link from "next/link";

export default async function Header() {
  return (
    <header className="flex justify-between bg-brand-500 h-20 px-12 py-2">
      <Link href="/" className="h-full">
        <Image
          width={220}
          height={35}
          src={Logo}
          alt="Logo"
          className="h-full rounded-xl p-1 hover:bg-brand-600"
        />
      </Link>
      <CategoriesButton />
      <SearchField />
      <div className="flex gap-16">
        <FavouriteButton />
        <CartButton
          cartSize={(await getCart()).reduce((a, p) => a + p.amount, 0)}
        />
        <MenuButton />
      </div>
    </header>
  );
}
