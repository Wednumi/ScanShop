"use client";

import { ReactNode } from "react";

type Props = {
  children: ReactNode;
};

export default function StopPropagationWrapper({ children }: Props) {
  return (
    <div
      className="w-full h-40 bg-white z-20 grid grid-cols-4 grid-rows-2 justify-items-start"
      onClick={(e) => e.stopPropagation()}
    >
      {children}
    </div>
  );
}
