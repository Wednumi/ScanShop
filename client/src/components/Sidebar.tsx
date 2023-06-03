"use client";

import Close from "@assets/close.png";
import Sale from "@assets/sale-products.png";
import News from "@assets/news.png";
import Info from "@assets/info.png";
import Reviews from "@assets/reviews.png";
import Bonuses from "@assets/bonuses.png";
import Profile from "@assets/profile.png";
import Logout from "@assets/logout.png";

import Image from "next/image";
import Link from "next/link";

type Props = {
  setShow: React.Dispatch<React.SetStateAction<boolean>>
}

export default function Sidebar({setShow}: Props) {
  return (
    <div className="fixed top-0 left-0 w-screen h-screen flex flex-col items-end bg-gray-600 bg-opacity-50 z-10" onClick={() => setShow(false)}>
      <div className="w-72 h-20 px-7 flex justify-end bg-brand-500 z-20" onClick={(e) => e.stopPropagation()}>
        <button onClick={() => setShow(false)}>
            <Image width={40} height={40} src={Close} alt="Close" />
        </button>
      </div>
      <div className="w-72 h-full bg-white flex flex-col justify-between items-start z-20" onClick={(e) => e.stopPropagation()}>
        <div className="w-auto h-auto px-3 py-5 flex flex-col">
          <Link href='/' className="w-auto flex gap-3 items-center p-3">
            <Image width={35} height={35} src={Sale} alt="Sale" />
            <p className="text-lg">Акції</p>
          </Link>
          <Link href='/' className="w-auto flex gap-3 items-center p-3">
            <Image width={35} height={35} src={News} alt="News" />
            <p className="text-lg">Новини</p>
          </Link>
          <Link href='/' className="w-auto flex gap-3 items-center p-3">
            <Image width={35} height={35} src={Info} alt="Info" />
            <p className="text-lg">Про нас</p>
          </Link>
          <Link href='/' className="w-auto flex gap-3 items-center p-3">
            <Image width={35} height={35} src={Reviews} alt="Reviews" />
            <p className="text-lg">Відгуки</p>
          </Link>
        </div>
        <div className="w-auto h-auto px-3 py-5 flex flex-col">
          <Link href='/' className="w-auto flex gap-3 items-center p-3">
            <Image width={35} height={35} src={Bonuses} alt="Bonuses" />
            <p className="text-lg">Бонусів: багато</p>
          </Link>
          <Link href='/' className="w-auto flex gap-3 items-center p-3">
            <Image width={35} height={35} src={Profile} alt="Profile" />
            <p className="text-lg">Мій кабінет</p>
          </Link>
          <Link href='/' className="w-auto flex gap-3 items-center p-3">
            <Image width={35} height={35} src={Logout} alt="Logout" />
            <p className="text-lg">Вийти з запису</p>
          </Link>
        </div>
      </div>      
    </div>
  )
}