"use client";

import Close from "@assets/close.png";

import Image from "next/image";

type Props = {
  setShow: React.Dispatch<React.SetStateAction<boolean>>;
};

export default function CategoryCancelButton({ setShow }: Props) {
  return (
    <div
      className="w-full h-20 bg-brand-500 z-20 flex items-center px-7"
      onClick={(e) => e.stopPropagation()}
    >
      <button
        className="flex items-center gap-4"
        onClick={() => setShow(false)}
      >
        <Image width={35} height={35} src={Close} alt="Close" />
        <h1 className="text-2xl text-white">Всі категорії</h1>
      </button>
    </div>
  );
}
