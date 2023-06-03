import Favourite from "@assets/favourite.png";

import Image from "next/image";

export default function FavouriteButton() {
  return (
    <button className="rounded p-2 pb-0 hover:bg-brand-600 w-16">
      <Image width={60} src={Favourite} alt="Favourite" className="h-full" />
    </button>
  );
}
