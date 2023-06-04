"use client";

import { ReactNode } from "react";

type Props = {
  children: ReactNode;
  setShow: React.Dispatch<React.SetStateAction<boolean>>;
  styles: string;
};

export default function OverlayEscape({ children, setShow, styles }: Props) {
  return (
    <div className={styles} onClick={() => setShow(false)}>
      {children}
    </div>
  );
}
