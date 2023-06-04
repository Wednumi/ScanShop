"use client";

import Menu from "@assets/burger-menu.png";
import OverlayElement from "@components/OverlayElement";
import Sidebar from "./Sidebar";

import Image from "next/image";
import { ReactNode, useEffect, useState } from "react";

type Props = {
  children: ReactNode;
  isLoggedIn: boolean;
};

export default function MenuButton({ children, isLoggedIn }: Props) {
  const [showMenu, setShowMenu] = useState(false);
  useEffect(() => {
    document.body.style.overflow = showMenu ? "hidden" : "unset";
  }, [showMenu]);

  return (
    <>
      {showMenu && (
        <OverlayElement
          element={
            <Sidebar isLoggedIn={isLoggedIn} setShow={setShowMenu}>
              {children}
            </Sidebar>
          }
        />
      )}
      <button
        className={"rounded p-2 pb-0 hover:bg-brand-600 w-16"}
        onClick={() => setShowMenu(true)}
      >
        <Image width={60} src={Menu} alt="Menu" className="h-full" />
      </button>
    </>
  );
}
