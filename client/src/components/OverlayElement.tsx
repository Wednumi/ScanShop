"use client";

import { createPortal } from "react-dom";

type Props = {
  element: React.ReactNode;
}

export default function OverlayElement({element}: Props) {
  const root = document.getElementById('overlay-root') as HTMLElement;

  return (
    createPortal(element, root)
  )
}