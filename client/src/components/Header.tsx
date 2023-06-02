"use client";

import { useEffect, useState } from "react";

import Logo from "@assets/Logo.png";
import Categories from "@assets/categories.png";
import Search from "@assets/search.png";
import Favourite from "@assets/favourite.png";
import Cart from "@assets/cart.png";
import Menu from "@assets/burger-menu.png";

import Image from "next/image";
import Link from "next/link";
import OverlayElement from "./OverlayElement";
import CartModal from "./CartModal";
import Sidebar from "./Sidebar";
import CategoriesBar from "./CategoriesBar";

export default function Footer() {
  const [showCart, setShowCart] = useState(false);
  const [showMenu, setShowMenu] = useState(false);
  const [showCategories, setShowCategories] = useState(false);

  useEffect(() => {
    document.body.style.overflow = showCart || showMenu || showCategories
      ? "hidden" : "unset";
  }, [showCart, showMenu, showCategories]);

  return (
    <>
      {showCart && <OverlayElement element={<CartModal setShow={setShowCart} />} />}
      {showMenu && <OverlayElement element={<Sidebar setShow={setShowMenu} />} />}
      {showCategories && <OverlayElement element={<CategoriesBar setShow={setShowCategories} />} />}
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
        <button className="rounded-xl bg-brand-700 flex p-3 gap-4 items-center hover:bg-brand-800"
          onClick={() => setShowCategories(true)}>
          <Image width={35} height={35} src={Categories} alt="Categories" />
          <h1 className="text-white font-bold text-xl">Каталог товарів</h1>
        </button>
        <div className="flex rounded-3xl bg-white p-3 gap-4 my-2 w-96">
          <button onClick={() => console.log("poopity scoop")}>
            <Image width={25} height={25} src={Search} alt="Search" />
          </button>
          <input type="text" placeholder="Пошук..." className="w-full" />
        </div>
        <div className="flex gap-16">
          <button className={"rounded p-2 pb-0 hover:bg-brand-600 w-16"}>
            <Image
              width={60}
              src={Favourite}
              alt="Favourite"
              className="h-full"
            />
          </button>
          <button className={"rounded p-2 pb-0 hover:bg-brand-600 w-16"}
            onClick={() => setShowCart(true)}>
            <Image width={60} src={Cart} alt="Cart" className="h-full" />
          </button>
          <button className={"rounded p-2 pb-0 hover:bg-brand-600 w-16"}
            onClick={() => setShowMenu(true)}>
            <Image width={60} src={Menu} alt="Menu" className="h-full" />
          </button>
        </div>
      </header>
    </>
  );
}
