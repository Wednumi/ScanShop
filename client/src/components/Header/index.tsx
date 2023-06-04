export const revalidate = 1;

import { getCart, getCategories, getUserInfo } from "@api";
import Logo from "@assets/logo.png";
import CategoriesButton from "./CategoriesButton";
import SearchField from "./SearchField";
import FavouriteButton from "./FavouriteButton";
import CartButton from "./CartButton";
import MenuButton from "./MenuButton";
import LogoutButton from "./LogoutButton";

import Image from "next/image";
import Link from "next/link";
import CartModalMakeOrder from "./CartModalMakeOrder";

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
      <CategoriesButton categories={await getCategories()} />
      <SearchField />
      <div className="flex gap-16">
        <FavouriteButton />
        <CartButton cart={await getCart()}>
          <CartModalMakeOrder />
        </CartButton>
        <MenuButton user={await getUserInfo()}>
          <LogoutButton />
        </MenuButton>
      </div>
    </header>
  );
}
