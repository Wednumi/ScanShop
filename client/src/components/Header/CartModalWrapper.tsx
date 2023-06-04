"use client";

import { ReactNode } from "react";

type Props = {
  children: ReactNode;
  setShow: React.Dispatch<React.SetStateAction<boolean>>;
};

export default function CartModalWrapper({ children, setShow }: Props) {
  return (
    <div
      onClick={() => setShow(false)}
      className="fixed top-0 left-0 w-screen h-screen flex justify-center items-center bg-gray-600 bg-opacity-50 z-10"
    >
      <div
        className="w-96 h-auto rounded-lg bg-white z-20 flex flex-col gap-4 items-center"
        onClick={(e) => e.stopPropagation()}
      >
        {children}
      </div>
    </div>
  );
}
