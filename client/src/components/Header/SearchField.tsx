"use client";

import Search from "@assets/search.png";

import Image from "next/image";

export default function SearchField() {
  return (
    <div className="flex rounded-3xl bg-white p-3 gap-4 my-2 w-96">
      <button onClick={() => console.log("poopity scoop")}>
        <Image width={25} height={25} src={Search} alt="Search" />
      </button>
      <input type="text" placeholder="Пошук..." className="w-full" />
    </div>
  );
}
