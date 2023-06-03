"use client";

import Facebook from "@assets/facebook.png";
import Instagram from "@assets/instagram.png";
import Twitter from "@assets/twitter.png";
import Youtube from "@assets/youtube.png";
import GooglePlay from "@assets/google-play.png";
import Logo from "@assets/logo-vert.png";
import Hotline from "@assets/hotline.png";

import Image from "next/image";
import Link from "next/link";

export default function Footer() {
  return (
    <footer className="flex justify-between bg-brand-500 h-32 px-12 py-2 text-white">
      <Link href="/" className="h-full">
        <Image
          src={Logo}
          alt="Logo"
          width={200}
          height={120}
          className="h-full rounded-xl p-1 hover:bg-brand-600"
        />
      </Link>
      <div className="grid grid-cols-1">
        <div className="flex justify-between w-full font-semibold text-2xl text-left">
          <Link href="/about">Про нас</Link>
          <Link href="/news">Новини</Link>
          <Link href="/discounts">Акції</Link>
          <Link href="/reviews">Відгуки</Link>
        </div>
        <div className="flex justify-between gap-48">
          <div className="flex flex-col mt-1">
            <span>Гаряча лінія</span>
            <div className="flex gap-0">
              <Image src={Hotline} alt="Hotline" width={25} />
              <span className="ml-1 font-semibold text-xl">0-800-500-765</span>
            </div>
          </div>
          <div className="flex flex-col mt-1">
            <span>E-mail</span>
            <span className="font-semibold text-xl">contact@scan&shop.ua</span>
          </div>
          <Link href="https://play.google.com" className="flex gap-2">
            <span className="bg-white rounded-full p-2 pl-3 pb-0 my-1">
              <Image src={GooglePlay} alt="Google Play" width={40} />
            </span>
            <div className="flex flex-col mt-1">
              <span>Android app</span>
              <span className="font-semibold text-xl">Google Play</span>
            </div>
          </Link>
        </div>
      </div>
      <div className="grid grid-cols-2 gap-2 my-2">
        <Link href="https://twitter.com" className="bg-white rounded-full p-1">
          <Image src={Twitter} alt="Twitter" width={40} />
        </Link>
        <Link
          href="https://instagram.com"
          className="bg-white rounded-full p-1"
        >
          <Image src={Instagram} alt="Instagram" width={40} />
        </Link>
        <Link href="https://facebook.com" className="bg-white rounded-full p-1">
          <Image src={Facebook} alt="Facebook" width={40} />
        </Link>
        <Link href="https://youtube.com" className="bg-white rounded-full p-1">
          <Image src={Youtube} alt="Youtube" width={40} />
        </Link>
      </div>
    </footer>
  );
}
